using System;
using System.Collections.Generic;
using System.Linq;
using TadManagementTool.Model;

namespace TadManagementTool.Service
{
    public class CollaboratorService : AbstractService
    {
        public IList<Collaborator> FindAll()
        {
            return restTemplate.GetForObject<IList<Collaborator>>("/collaborators");
        }

        public void RemoveCollaborator(Collaborator collaborator)
        {
            restTemplate.Delete("/collaborator/{id}", collaborator.Id);
        }

        public void SaveCollaborator(Collaborator collaborator)
        {
            restTemplate.PostForMessage("/collaborator", collaborator);
        }

        public void ExportToExcel(IList<Collaborator> collaborators, string filePath)
        {
            var exporter = new ListCollaboratorExporter();
            exporter.ExportTo(collaborators, filePath);
        }

        public BirthdayList[] FindCurrentYearBirthDays()
        {
            var collaborators = FindAll();
            var birthDayMap = new Dictionary<MonthOfBirthday, BirthdayList>();
            var currentDateTime = DateTime.Now;
            foreach (var collaborator in collaborators.Where(c => c.Active && c.BirthDate.Month >= currentDateTime.Month).OrderBy(c => c.BirthDate.Month))
            {
                BirthdayList found;
                var monthOfBirthday = new MonthOfBirthday(collaborator.BirthDate.Month);
                if (!birthDayMap.TryGetValue(monthOfBirthday, out found))
                {
                    found = new BirthdayList(monthOfBirthday);
                    birthDayMap.Add(monthOfBirthday, found);
                }
                found.Add(collaborator.Person);
            }
            return birthDayMap.Values.OrderBy(p => p.CurrentMonth.Month).ToArray();
        }
    }
}
