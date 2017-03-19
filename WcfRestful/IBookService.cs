using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Services;
using WcfRestful.Models;

namespace WcfRestful
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IBookService”。
    [ServiceContract]
    public interface IBookService
    {
        [WebGet(UriTemplate = "book/list", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        List<Book> GetList();

        ///// <summary>
        ///// 如果调用段有多个查询条件，可以先将查询条件组织成 json 格式， 然后在通过参数 query 传递。后台对参数进行反序列化
        ///// </summary>
        ///// <param name="query"></param>
        ///// <returns></returns>
        //[WebGet(UriTemplate = "book/list/?query={query}", ResponseFormat = WebMessageFormat.Json)]
        //[OperationContract]
        //List<Book> GetList(string query);


        [WebGet(UriTemplate = "book/list/{id}/{name}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        Book GetById(string id, string name);
        
        [WebInvoke(
            UriTemplate = "book/add", 
            Method = "POST", 
            RequestFormat = WebMessageFormat.Json, 
            ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        List<Book> Add(Book model);


        [WebInvoke(
            UriTemplate = "book/update", 
            Method = "PUT", 
            RequestFormat = WebMessageFormat.Json, 
            ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        List<Book> Update(Book book);

        [WebInvoke(
            UriTemplate = "book/delete/{id}", 
            Method = "DELETE", 
            ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        List<Book> Delete(string id);
    }
}
