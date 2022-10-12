using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAsistantInvestigatorService
    {
        IDataResult<List<AssistantInvestigator>> GetAll();
        IResult Add(AssistantInvestigator assistantInvestigator);
        IResult Delete(AssistantInvestigator assistantInvestigator);
        IResult Update(AssistantInvestigator assistantInvestigator);
        IDataResult<AssistantInvestigator> GetById(int Id);
    }
}
