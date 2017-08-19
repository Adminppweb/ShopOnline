using ShopOnlineConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnlineBus.Bus
{
    public class SanPhamBus
    {
        public static IEnumerable<viewSanPham> List()
        {
            var db = new ShopOnlineConnectionDB();
            return db.Query<viewSanPham>("SELECT * FROM viewSanPham");
        }
        public static SanPham GetById(int id)
        {
            var db = new ShopOnlineConnectionDB();
            return db.SingleOrDefault<SanPham>("select * from SanPham where ID_SP = @0", id);
        }
    }
}
