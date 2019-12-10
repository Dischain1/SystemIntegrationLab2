using Model;
using System;
using System.Collections.Generic;
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

        public string Test()
        {
            return "hello";
        }

        public List<DepositDto> GetDeposits()
        {
            return db.Месторождения
                .Select(x => new DepositDto { ID = x.ID, Name = x.Название })
                .ToList();
        }
        #endregion
    }
}
