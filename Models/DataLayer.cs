using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using System;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace DemoMVC.Models
{
    public class DataLayer
    {
       /* public string GetData_BYID(string ID)
        {
            string Data = null;
            try
            {
                var con = configurationmanager.connectionstrings["connectionstring"].connectionstring; ;
                mongoclient client_ = new mongoclient(con);
                mongoserver server_ = client_.getserver();

                databasename dname = new databasename();

                dname.database = configurationmanager.appsettings["mongodatabase"].tostring();

                dname.collectionname = "UserCollection";

                mongodatabase db = server_.getdatabase(dname.database);


                // database connection string and client and servr connect with database of mongo db //


                mongocollection<docreports> col = db.getcollection<docreports>(dname.collectionname);
                if (col.exists())
                {
                    reportclass obj = new reportclass();
                    mongogridfs gfs = new mongogridfs(db);
                    string hfvalue = string.empty;
                    system.collections.arraylist a1 = new system.collections.arraylist();
                    var data = col.find(query.and(query.eq("Name", refno)));
                    
                    foreach (docreports item in data)
                    {
                        objectid _documentid = new objectid(item.docid.tostring());
                        mongogridfsfileinfo _fileinfo = db.gridfs.findone(query.eq("_id", _documentid));
                        string base64;
                        using (var stream = _fileinfo.openread())
                        {
                            var bytes = new byte[stream.length];
                            stream.read(bytes, 0, (int)stream.length);
                            base64 = convert.tobase64string(bytes);

                            obj.filename = item.docname.tostring();
                            obj.signdata = base64;
                            obj.billnoid = item.billnoid.tostring();
                        }
                    }
                }
                else
                {
                    Data = "Collection doesn't exists";
                    
                }
                return Data;
            }
            catch
            {
                Data = "-1";
                return Data;
            }
             
        }
*/
    }
    public class DataClass
    {
        public string dataByte { get; set; }
        public string ID { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
    }
}