using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfRestful.Models;

namespace WcfRestful
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“BookService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 BookService.svc 或 BookService.svc.cs，然后开始调试。
    public class BookService : IBookService
    {
        private List<Book> _dataSource = new List<Book>()
        {
            new Book() {Id = 1, Name = "西游记", Price = 23},
            new Book() {Id = 2, Name = "红楼梦", Price = 22},
            new Book() {Id = 3, Name = "封神榜", Price = 23},
            new Book() {Id = 4, Name = "金瓶梅", Price = 33},
            new Book() {Id = 5, Name = "水浒传", Price = 25}
        }; 


        public List<Book> GetList()
        {
            return _dataSource;
        }

        public Book GetById(string id, string name)
        {
            int idValue = int.TryParse(id, out idValue) ? idValue : 1;
            return _dataSource.FirstOrDefault(p => p.Id == idValue);
        }

        public List<Book> Add(Book model)
        {
            if (model == null)
            {
                model = new Book();
            }
            model.Id = _dataSource.Max(p => p.Id) + 1;
            _dataSource.Add(model);

            return _dataSource;
        }

        public List<Book> Update(Book model)
        {
            if (model == null)
                return _dataSource;
            var book = _dataSource.FirstOrDefault(p => p.Id == model.Id);
            if (book == null)
                return _dataSource;
            book.Name = model.Name;
            book.Price = model.Price;

            return _dataSource;
        }

        public List<Book> Delete(string id)
        {
            int idValue = int.TryParse(id, out idValue) ? idValue : 1;
            var model = _dataSource.FirstOrDefault(p => p.Id == idValue);
            if (model == null)
                return _dataSource;
            _dataSource.Remove(model);
            return _dataSource;
        } 
    }
}
