using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SystemIntegrationLab2
{
    public class DataService : IDataService
    {
        readonly Context db;

        public DataService()
        {
            db = new Context();
        }

        public string Test()
        {
            return "hello";
        }

        #region ReadOperastions
        public ResponceAndDataList<DepositDto> ReadDeposits()
        {
            try
            {
                List<DepositDto> deposits = db.Месторождения
                    .Select(x => new DepositDto { ID = x.ID, Name = x.Название })
                    .ToList();

                return new ResponceAndDataList<DepositDto>
                {
                    Responce = Responce.CreateOkRespond(),
                    Data = deposits
                };
            }
            catch (Exception e)
            {
                return new ResponceAndDataList<DepositDto> { Responce = Responce.CreateErrorRespond(e.Message)};
            }
        }
        public ResponceAndDataList<WellDto> ReadWells(Guid depositId)
        {
            try
            {
                List<WellDto> wells = db.Скважины
                    .Where(w => w.ID_Месторождения == depositId)
                    .Select(x => new WellDto { ID = x.ID, Number = x.Номер })
                    .ToList();

                return new ResponceAndDataList<WellDto>
                {
                    Responce = Responce.CreateOkRespond(),
                    Data = wells
                };

            }
            catch (Exception e)
            {
                return new ResponceAndDataList<WellDto> { Responce = Responce.CreateErrorRespond(e.Message)};
            }
        }
        public ResponceAndDataList<ExtractionDto> ReadExtractions(Guid wellId, string dateFrom, string dateTo)
        {
            var _dateFrom = dateFrom.GetDate();
            var _dateTo = dateTo.GetDate();
            try
            {
                List<ExtractionDto> extractions = db.Добыча
                    .Where
                    (
                        e =>
                            e.ID_Скважины == wellId
                            && e.Дата >= _dateFrom
                            && e.Дата <= _dateTo
                    )
                    .Select(x => new ExtractionDto { ID = x.ID_Добычи, Value = x.Значение, Date = x.Дата })
                    .ToList();

                return new ResponceAndDataList<ExtractionDto>
                {
                    Responce = Responce.CreateOkRespond(),
                    Data = extractions
                };
            }
            catch (Exception e)
            {
                return new ResponceAndDataList<ExtractionDto> { Responce = Responce.CreateErrorRespond(e.Message) };
            }
        }
        #endregion

        #region DeleteOperastions
        public Responce DeleteDeposit(Guid depositId)
        {
            try
            {
                Месторождения deposit = db.Месторождения.Find(depositId);

                if (!deposit.Скважины.Any())
                {
                    db.Месторождения.Remove(deposit);
                    db.SaveChanges();
                    return Responce.CreateOkRespond();
                }
                else
                {
                    return Responce.CreateErrorRespond("Сначала нужно удалить связанные Скважины.");
                }

            }
            catch (Exception e)
            {
                return Responce.CreateErrorRespond(e.Message);
            }
        }
        public Responce DeleteWell(Guid wellId)
        {
            try
            {
                Скважины well = db.Скважины.Find(wellId);
                if (!well.Добыча.Any())
                {
                    db.Скважины.Remove(well);
                    db.SaveChanges();

                    return Responce.CreateOkRespond();
                }
                else
                {
                    return Responce.CreateErrorRespond("Сначала нужно удалить связанные Добычи.");
                }
            }
            catch (Exception e)
            {
                return Responce.CreateErrorRespond(e.Message);
            }
        }
        public Responce DeleteExtraction(Guid extractionId)
        {
            try
            {
                Добыча extraction = db.Добыча.Find(extractionId);

                db.Добыча.Remove(extraction);
                db.SaveChanges();

                return Responce.CreateOkRespond();
            }
            catch (Exception e)
            {
                return Responce.CreateErrorRespond(e.Message);
            }
        }
        #endregion

        #region UpdateOperastions
        public Responce UpdateDeposit(Guid depositId, string name)
        {
            try
            {
                Месторождения deposit = db.Месторождения.Find(depositId);
                deposit.Название = name;
                //db.Entry(deposit).State = EntityState.Modified;
                db.SaveChangesAsync();
                return Responce.CreateOkRespond();
            }
            catch (Exception e)
            {
                return Responce.CreateErrorRespond(e.Message);
            }
        }
        public Responce UpdateWell(Guid wellId, string number)
        {
            try
            {
                Скважины well = db.Скважины.Find(wellId);
                well.Номер = number;
                db.Entry(well).State = EntityState.Modified;
                db.SaveChangesAsync();

                return Responce.CreateOkRespond();

            }
            catch (Exception e)
            {
                return Responce.CreateErrorRespond(e.Message);
            }
        }
        public Responce UpdateExtraction(Guid extractionId, string date, double value)
        {
            try
            {
                Добыча extraction = db.Добыча.Find(extractionId);
                extraction.Дата = date.GetDate();
                extraction.Значение = value;

                db.Entry(extraction).State = EntityState.Modified;
                db.SaveChangesAsync();

                return Responce.CreateOkRespond();

            }
            catch (Exception e)
            {
                return Responce.CreateErrorRespond(e.Message);
            }
        }
        #endregion

        #region CreateOperastions
        public Responce CreateDeposit(string name, string type, string openDate)
        {
            try
            {
                Месторождения deposit = new Месторождения
                {
                    Название = name,
                    Тип = type,
                    Дата_открытия = openDate.GetDate()
                };

                db.Месторождения.Add(deposit);
                db.SaveChangesAsync();

                return Responce.CreateOkRespond();

            }
            catch (Exception e)
            {
                return Responce.CreateErrorRespond(e.Message);
            }
        }
        public Responce CreateWell(Guid depositId, string number, string type, int depth, string drillingDate)
        {
            try
            {
                Скважины well = new Скважины
                {
                    Номер = number,
                    Глубина = depth,
                    Тип = type,
                    Дата_бурения = drillingDate.GetDate(),
                    ID_Месторождения = depositId
                };

                db.Скважины.Add(well);

                db.SaveChangesAsync();
                return Responce.CreateOkRespond();

            }
            catch (Exception e)
            {
                return Responce.CreateErrorRespond(e.Message);
            }
        }
        public Responce CreateExtraction(Guid wellId, string date, double value)
        {
            try
            {
                Добыча extraction = new Добыча
                {
                    Дата = date.GetDate(),
                    Значение = value,
                    ID_Скважины = wellId
                };

                db.Добыча.Add(extraction);

                db.SaveChangesAsync();
                return Responce.CreateOkRespond();

            }
            catch (Exception e)
            {
                return Responce.CreateErrorRespond(e.Message);
            }
        }
        #endregion
    }
}
