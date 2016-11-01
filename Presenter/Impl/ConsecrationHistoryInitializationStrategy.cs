using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TadManagementTool.Model;
using TadManagementTool.View.Impl;

namespace TadManagementTool.Presenter.Impl
{
    public class ConsecrationHistoryInitializationStrategy : IConsecrationInitializationStrategy
    {
        private readonly Consecration consecration;

        public ConsecrationHistoryInitializationStrategy(Consecration consecration)
        {
            this.consecration = consecration;
        }

        public Consecration GetConsecration()
        {
            return consecration;
        }
    }
}
