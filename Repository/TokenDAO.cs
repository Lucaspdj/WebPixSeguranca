using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class TokenDAO
    {
        public static bool Save(Token obj)
        {
            obj.DataCriacao = DateTime.Now;
            obj.DateAlteracao = DateTime.Now;
            try
            {
                if (obj.ID == 0)
                {
                    using (var db = new WebPixContext())
                    {
                        db.Token.Add(obj);
                        db.SaveChanges();
                    }
                    return true;
                }
                else
                {
                    using (var db = new WebPixContext())
                    {

                        db.Token.Update(obj);
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static List<Token> GetAll()
        {
            try
            {
                using (var db = new WebPixContext())
                {
                    return db.Token.ToList();
                }
            }
            catch (Exception e)
            {
                ////
                return new List<Token>();
            }

        }
        public static bool Remove(Token obj)
        {
            try
            {
                using (var db = new WebPixContext())
                {
                    db.Token.Remove(obj);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                ////
                return false;
            }

        }
    }
}
