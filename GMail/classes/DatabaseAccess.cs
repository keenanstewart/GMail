using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;

using System.Configuration;
using System.Web.Configuration;

using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace GMail.classes
{
    public class DatabaseAccess
    {
		public static bool VerifyLogin(string strUsername, string strPassword)
		//public static string VerifyLogin(string strUsername, string strPassword)
		{
            string strSchema = WebConfigurationManager.AppSettings["passschema"];
            //string strtblPassword = WebConfigurationManager.AppSettings["tblPassword"];
            string strtblUsers = WebConfigurationManager.AppSettings["tblUsers"];

            string strConn = DBConnection();

            string strQuery = "use [www]; SELECT * FROM [" + strSchema + "].[" + strtblUsers + "] ";
            strQuery += "WHERE [username] = @u AND [Password] = @p;";
			try
			{
				using (SqlConnection con1 = new SqlConnection(strConn))
				{
					using (SqlCommand cmd1 = new SqlCommand(strQuery, con1))
					{
						try
						{
							con1.Open();
							cmd1.Parameters.AddWithValue("@u", strUsername);
							cmd1.Parameters.AddWithValue("@p", strPassword);

							SqlDataReader read1 = cmd1.ExecuteReader();

							while (read1.Read())
							{
								if ((read1["Username"].ToString() == strUsername) &&
								    (read1["Password"].ToString() == strPassword))
									//return "match found true";
									return true;
							}

							con1.Close();
						}

						catch (Exception)
						{
						}
					}
				}
			}

			catch (Exception ex)
			{
				//return "Exception caught: " + ex.Message.ToString() + ":" +
				//	strConn + ":" + strQuery;
				return false;
			}

			//return "false";
			return false;
        }

        public static string DBTable()
        {
            try
            {
                string strDebug = WebConfigurationManager.AppSettings["live"];

                if (strDebug.ToLower() == "live")
                {
                    return WebConfigurationManager.AppSettings["WordsmithWords"] + ";" + 
                        WebConfigurationManager.AppSettings["WordsmithThemes"];
                }

                else
                {
                    return WebConfigurationManager.AppSettings["TestWordsmithWords"] + ";" +
                        WebConfigurationManager.AppSettings["TestWordsmithThemes"];
                }
            }

            catch (Exception ex1)
            {
                return "Connection error: " + ex1.Message.ToString();
            }
        }

        public static string Encrypt(string strToEncrypt)
        {
            string EncryptionKey = WebConfigurationManager.AppSettings["EncryptionKey"];
            byte[] clearBytes = Encoding.Unicode.GetBytes(strToEncrypt);

            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[]
                        {
                            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
                        });

                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(),
                        CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }

                    strToEncrypt = Convert.ToBase64String(ms.ToArray());
                }
            }
            return strToEncrypt;
        }

        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = WebConfigurationManager.AppSettings["EncryptionKey"];
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);

            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[]
                        {
                            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
                        });

                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(),
                        CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }

                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }

            return cipherText;
        }

        public static string DBConnection()
        {
            try
            {
                string strDebug = WebConfigurationManager.AppSettings["live"];

                if (strDebug.ToLower() == "live")
                {
                    return WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                }

                else
                {
                    return WebConfigurationManager.ConnectionStrings["DefaultConnectionDebug"].ConnectionString;
                }
            }

            catch (Exception ex1)
            {
                return "Connection error: " + ex1.Message.ToString();
            }
        }

    }
}