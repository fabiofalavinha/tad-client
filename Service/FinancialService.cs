using System;
using System.Collections.Generic;
using TadManagementTool.Model;
using TadManagementTool.Model.Financial;
using TadManagementTool.Service.VOs;

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

        public IList<FinancialEntry> FindFinancialEntryBy(DateTime from, DateTime to)
        {
            return restTemplate.GetForObject<IList<FinancialEntry>>("/financial/entries/{from}/{to}", from.ToString("yyyy-MM-dd"), to.ToString("yyyy-MM-dd"));
        }

        public IList<FinancialTarget> FindTargets()
        {
            return restTemplate.GetForObject<IList<FinancialTarget>>("/financial/targets");
        }

        public Balance GetCurrentTotalBalance()
        {
            return restTemplate.GetForObject<Balance>("/financial/balance");
        }

        public void SaveFinancialEntry(FinancialEntry financialEntry)
        {
            restTemplate.PostForObject<FinancialEntry>("/financial/entry", financialEntry);
        }

        public void CloseBalance(User user)
        {
            restTemplate.PostForObject<CloseFinancialEntryBalanceDTO>("/financial/close", new CloseFinancialEntryBalanceDTO() { UserId = user.Id });
        }
    }
}
