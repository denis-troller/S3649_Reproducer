using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace S3649_Reproducer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class S3469Controller : ControllerBase
    {
        private readonly MyDBContext _ctx;
        public S3469Controller(MyDBContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet("/exists1")]
        public bool GetEntityExists1(string name)
        {
            return EntityExists1(name);
        }

        private bool EntityExists1(string name)
        {
            var query = "SELECT * FROM Entity1s WHERE Name = '" + name + "'";
            var e2 = _ctx.Entity1s.FromSqlRaw(query).ToList();
            return e2.Any();
        }

        [HttpGet("/exists2")]
        public bool GetEntityExists2(string name)
        {
            return EntityExists2(name);
        }

        private bool EntityExists2(string name)
        {
            var query = "SELECT * FROM Entity1s WHERE Name = '" + name + "'";
            var e2 = _ctx.Database.SqlQueryRaw<int>(query).ToList();
            return e2.Any();
        }
    }
}
