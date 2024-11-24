using Base.Models;
using Base.Services;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace BaoLib.Services
{
    //for dropdown input
    public static class _XpLibCode
    {
        /*
        #region master table to codes
        public static async Task<List<IdStrDto>> GetProjectsA(Db? db = null)
        {
            return await ByTableA("Project", db);
        }
        public static async Task<List<IdStrDto>> GetUsersA(Db? db = null)
        {
            return await ByTableA("User", db);
        }
        public static async Task<List<IdStrDto>> GetDeptsA(Db? db = null)
        {
            return await ByTableA("Dept", db);
        }
        public static async Task<List<IdStrDto>> GetRolesA(Db? db = null)
        {
            return await ByTableA("XpRole", db);
        }
        public static async Task<List<IdStrDto>> GetProgsA(Db? db = null)
        {
            //return TableToList("XpProg", db);
            var sql = @"
select 
    Id, (case when AuthRow=1 then '*' else '' end)+Name as Str
from dbo.XpProg
order by Id";
            return await BySqlA(sql, db);
        }
        public static async Task<List<IdStrDto>> GetFlowsA(Db? db = null)
        {
            return await ByTableA("XpFlow", db);
        }
        #endregion
        */

        #region get from XpCode table
        public static async Task<List<IdStrDto>> LaunchStatusesA(Db? db = null)
        {
            return await ByTypeA("LaunchStatus", db);
        }
        public static async Task<List<IdStrDto>> AnswerTypesA(Db? db = null)
        {
            return await ByTypeA(_XpLib.AnswerType, db);
        }
        public static async Task<List<IdStrDto>> PrizeTypesA(Db? db = null)
        {
            return await ByTypeA("PrizeType", db);
        }
        #endregion

        public static async Task<List<IdStrDto>> BySqlA(string sql, Db? db = null)
        {
            return await _Db.SqlToCodesA(sql, db) ?? [] ;
        }

        //傳回非null方便前端使用
        private static async Task<List<IdStrDto>> ByTableA(string table, Db? db = null)
        {
            var sql = string.Format(@"
select 
    Id, Name as Str
from dbo.[{0}]
order by Id
", table);
            return await _Db.SqlToCodesA(sql, db) ?? [];
        }

        /*
        //get codes from sql 
        private static async Task<List<IdStrDto>> SqlToListAsync(string sql, Db? db = null)
        {
            var emptyDb = false;
            _Fun.CheckOpenDb(ref db, ref emptyDb);

            var rows = await db.GetModelsA<IdStrDto>(sql);
            await _Fun.CheckCloseDbA(db, emptyDb);
            return rows;
        }
        */

        //get code table rows
        private static async Task<List<IdStrDto>> ByTypeA(string type, Db? db = null)
        {
            var sql = $@"
select 
    Value as Id, Name as Str
from dbo.XpCode
where Type='{type}'
order by Sort";
            return await _Db.SqlToCodesA(sql, db) ?? [];
        }

    }//class
}
