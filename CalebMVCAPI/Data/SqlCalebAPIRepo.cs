using System;
using System.Collections.Generic;
using System.Linq;
using CalebMVCAPI.Models;

namespace CalebMVCAPI.Data
{
   public class SqlCalebAPIRepo : IcalebAPIRepo
   {
      private calebAPIContext _context;

      public SqlCalebAPIRepo(calebAPIContext context)
      {
         _context = context;
      }

      public void CreateCommand(calebModels cmd)
      {
         if (cmd == null)
         {
            throw new ArgumentNullException(nameof(cmd));
         }

         _context.calebModelDB.Add(cmd);
      }

      public void DeleteCommand(calebModels cmd)
      {
         if (cmd == null)
         {
            throw new ArgumentNullException(nameof(cmd));
         }
         _context.calebModelDB.Remove(cmd);
      }

      public IEnumerable<calebModels> GetAllCommands()
      {
         return _context.calebModelDB.ToList();
      }

      public calebModels GetCommandById(int id)
      {
         return _context.calebModelDB.FirstOrDefault(p => p.Id == id);
      }

      public bool SaveChanges()
      {
         return (_context.SaveChanges() >= 0);
      }

      public void UpdateCommand(calebModels cmd)
      {
         //WE IMPLEMENT THE INTERFACE BY DOING NOTHING
      }
   }
}