using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TadManagementTool.Model.Financial;

namespace TadManagementTool.Service
{
    public class FinancialService : AbstractService
    {
        public IList<FinancialReference> GetFinancialReferences()
        {
            return restTemplate.GetForObject<IList<FinancialReference>>("/financial/references");
        }

        public void SaveFinancialReference(FinancialReference financialReference)
        {
            restTemplate.PostForObject<FinancialReference>("/financial/reference", financialReference);
        }

        public void RemoveFinancialReference(FinancialReference financialReference)
        {
            restTemplate.Delete("/financial/reference/{id}", financialReference.Id);
        }
    }
}
