using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.OleDb;
using IConsolidator.Models;
using System.Diagnostics;

namespace IConsolidator.Controllers
{
    public class DataController : ApiController
    {
        // GET: api/Data
        public IEnumerable<Stock> Get()
        {
            Request.GetQueryNameValuePairs();

            int pageLength = 50;
            string search = "";

            foreach (var parameter in Request.GetQueryNameValuePairs())
            {
                var key = parameter.Key;
                var value = parameter.Value;

                if (key == "search" && value != "")
                {
                    search = " WHERE UCASE(description) LIKE '%" + parameter.Value.ToUpper() + "%'";
                }
            }


            OleDbConnection oleConn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\recent.mdb");

            string queryString = "SELECT TOP " + pageLength + " * FROM Stock" + search;

            var command = new OleDbCommand(queryString, oleConn);

            oleConn.Open();

            var reader = command.ExecuteReader();

            List<Stock> listStr = new List<Stock>();

            while (reader.Read())
            {
                Stock s = new Stock();

                s.ID = int.Parse(reader["stock_id"].ToString());
                s.ItemName = reader["description"].ToString();
                s.Quantity = int.Parse(reader["quantity"].ToString());

                listStr.Add(s);
            }

            oleConn.Close();

            return listStr;
        }

        // GET: api/Data/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Data
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Data/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Data/5
        public void Delete(int id)
        {
        }
    }
}
