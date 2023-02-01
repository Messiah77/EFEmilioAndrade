using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using EFEmilioAndrade.JEAIModels;


namespace EFEmilioAndrade.JEAIData
{
    public class JEAISateliteDataBase
    {
        string _dbPath;
        private SQLiteConnection conn;

        public JEAISateliteDataBase(string DatabasePath)
        {
            _dbPath = DatabasePath;
        }

        private void Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Satelite>();
        }

        public int UpadateSatelite(Satelite satelite)
        {
            Init();
            int result = conn.Update(satelite);
            return result;
        }

        public int DeleteSatelite(Satelite satelite)
        {
            Init();
            int result = conn.Delete(satelite);
            return result;
        }

        public Satelite GetSatelite(int id)
        {
            Satelite B1 = new Satelite();
            Init();
            List<Satelite> satelite = conn.Table<Satelite>().ToList();
            foreach (Satelite B2 in satelite)
            {
                if (B2.id == id)
                    B1 = B2;
            }
            return B1;
        }

        public List<Satelite> GetAllSatelite()
        {
            Init();
            List<Satelite> satelite = conn.Table<Satelite>().ToList();
            return satelite;
        }

    }
}
