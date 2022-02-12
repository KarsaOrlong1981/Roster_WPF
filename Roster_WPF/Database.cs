using Roster_WPF.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster_WPF
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;
        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Employee>().Wait();
        }
        public Task<List<Employee>> GetAllItemsAsync()
        {
            return _database.Table<Employee>().ToListAsync();
        }
        public Task<int> AddToDBAsync(Employee person)
        {
            return _database.InsertAsync(person);
        }
        public async Task DeleteItemAsync(int id)
        {
            var item = await _database.Table<Employee>().Where(x => x.Id == id).FirstOrDefaultAsync();
            if (item != null)
            {
                await _database.DeleteAsync(item);
            }
        }
        public Task<Employee> GetItemAsync(int id)
        {
            return _database.Table<Employee>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }
        public Task<int> DeleteAllItems<T>()
        {
            return _database.DeleteAllAsync<Employee>();
        }
        public Task<int> GetDBCount()
        {
            return _database.Table<Employee>().CountAsync();
        }
    }
}
