using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AsistantInvestigatorManager : IAsistantInvestigatorService
    {
        IAsistantInvestigatorDal _asistantInvestigatorDal;

        public AsistantInvestigatorManager(IAsistantInvestigatorDal asistantInvestigatorDal)
        {
            _asistantInvestigatorDal = asistantInvestigatorDal;
        }

        public IResult Add(AssistantInvestigator assistantInvestigator)
        {
            _asistantInvestigatorDal.Add(assistantInvestigator);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(AssistantInvestigator assistantInvestigator)
        {
            _asistantInvestigatorDal.Delete(assistantInvestigator);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<AssistantInvestigator>> GetAll()
        {
            return new SuccessDataResult<List<AssistantInvestigator>>(_asistantInvestigatorDal.GetAll(), Messages.Listed);
        }

        public IDataResult<AssistantInvestigator> GetById(int Id)
        {
            return new SuccessDataResult<AssistantInvestigator>(_asistantInvestigatorDal.GetById(Id), Messages.Listed);

        }

        public IResult Update(AssistantInvestigator assistantInvestigator)
        {
            _asistantInvestigatorDal.Update(assistantInvestigator);
            return new SuccessResult(Messages.Updated);
        }
    }
}
