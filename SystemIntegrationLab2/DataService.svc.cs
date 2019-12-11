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
        public RespondAndDataList<DepositDto> ReadDeposits()
        {
            try
            {
                List<DepositDto> deposits = db.Месторождения
                    .Select(x => new DepositDto { ID = x.ID, Name = x.Название })
                    .ToList();

                return new RespondAndDataList<DepositDto>
                {
                    Respond = Respond.CreateOkRespond(),
                    Data = deposits
                };
            }
            catch (Exception e)
            {
                return new RespondAndDataList<DepositDto> { Respond = Respond.CreateErrorRespond(e.Message)};
            }
        }
        public RespondAndDataList<WellDto> ReadWells(Guid depositId)
        {
            try
            {
                List<WellDto> wells = db.Скважины
                    .Where(w => w.ID_Месторождения == depositId)
                    .Select(x => new WellDto { ID = x.ID, Number = x.Номер })
                    .ToList();

                return new RespondAndDataList<WellDto>
                {
                    Respond = Respond.CreateOkRespond(),
                    Data = wells
                };

            }
            catch (Exception e)
            {
                return new RespondAndDataList<WellDto> { Respond = Respond.CreateErrorRespond(e.Message)};
            }
        }
        public RespondAndDataList<ExtractionDto> ReadExtractions(Guid wellId, string dateFrom, string dateTo)
        {
            try
            {
                List<ExtractionDto> extractions = db.Добыча
                    .Where
                    (
                        e =>
                            e.ID_Скважины == wellId
                            && e.Дата >= dateFrom.GetDate()
                            && e.Дата <= dateTo.GetDate()
                    )
                    .Select(x => new ExtractionDto { ID = x.ID_Добычи, Значение = x.Значение })
                    .ToList();

                return new RespondAndDataList<ExtractionDto>
                {
                    Respond = Respond.CreateOkRespond(),
                    Data = extractions
                };
            }
            catch (Exception e)
            {
                return new RespondAndDataList<ExtractionDto> { Respond = Respond.CreateErrorRespond(e.Message) };
            }
        }
        #endregion

        #region DeleteOperastions
        public Respond DeleteDeposit(Guid depositId)
        {
            try
            {
                Месторождения deposit = db.Месторождения.Find(depositId);

                if (!deposit.Скважины.Any())
                {
                    db.Месторождения.Remove(deposit);
                    db.SaveChanges();
                    return Respond.CreateOkRespond();
                }
                else
                {
                    return Respond.CreateErrorRespond("Сначала нужно удалить связанные Скважины.");
                }

            }
            catch (Exception e)
            {
                return Respond.CreateErrorRespond(e.Message);
            }
        }
        public Respond DeleteWell(Guid wellId)
        {
            try
            {
                Скважины well = db.Скважины.Find(wellId);
                if (!well.Добыча.Any())
                {
                    db.Скважины.Remove(well);
                    db.SaveChanges();

                    return Respond.CreateOkRespond();
                }
                else
                {
                    return Respond.CreateErrorRespond("Сначала нужно удалить связанные Добычи.");
                }
            }
            catch (Exception e)
            {
                return Respond.CreateErrorRespond(e.Message);
            }
        }
        public Respond DeleteExtraction(Guid extractionId)
        {
            try
            {
                Добыча extraction = db.Добыча.Find(extractionId);

                db.Добыча.Remove(extraction);
                db.SaveChanges();

                return Respond.CreateOkRespond();
            }
            catch (Exception e)
            {
                return Respond.CreateErrorRespond(e.Message);
            }
        }
        #endregion

        #region UpdateOperastions
        public Respond UpdateDeposit(Guid depositId, string name)
        {
            try
            {
                Месторождения deposit = db.Месторождения.Find(depositId);
                deposit.Название = name;
                //db.Entry(deposit).State = EntityState.Modified;
                db.SaveChangesAsync();
                return Respond.CreateOkRespond();
            }
            catch (Exception e)
            {
                return Respond.CreateErrorRespond(e.Message);
            }
        }
        public Respond UpdateWell(Guid wellId, string number)
        {
            try
            {
                Скважины well = db.Скважины.Find(wellId);
                well.Номер = number;
                db.Entry(well).State = EntityState.Modified;
                db.SaveChangesAsync();

                return Respond.CreateOkRespond();

            }
            catch (Exception e)
            {
                return Respond.CreateErrorRespond(e.Message);
            }
        }
        public Respond UpdateExtraction(Guid extractionId, string date, double value)
        {
            try
            {
                Добыча extraction = db.Добыча.Find(extractionId);
                extraction.Дата = date.GetDate();
                extraction.Значение = value;

                db.Entry(extraction).State = EntityState.Modified;
                db.SaveChangesAsync();

                return Respond.CreateOkRespond();

            }
            catch (Exception e)
            {
                return Respond.CreateErrorRespond(e.Message);
            }
        }
        #endregion

        #region CreateOperastions
        public Respond CreateDeposit(string name, string type, string openDate)
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

                return Respond.CreateOkRespond();

            }
            catch (Exception e)
            {
                return Respond.CreateErrorRespond(e.Message);
            }
        }
        public Respond CreateWell(Guid depositId, string number, string type, int depth, string drillingDate)
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
                return Respond.CreateOkRespond();

            }
            catch (Exception e)
            {
                return Respond.CreateErrorRespond(e.Message);
            }
        }
        public Respond CreateExtraction(Guid wellId, string date, double value)
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
                return Respond.CreateOkRespond();

            }
            catch (Exception e)
            {
                return Respond.CreateErrorRespond(e.Message);
            }
        }
        #endregion
    }
}
