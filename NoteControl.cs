using EasyNote.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyNote.Controlers
{
    class NoteControl
    {   
        //login
        public static bool SignIn(string username, string pass)
        {
            var id = (from u in fmNote._context.LoginUsers
                        where u.Password == pass && u.Username == username
                        select u).ToList();
            if (id.Count == 1) return true;
            else return false;  
        }

        //register
        public static bool RegisterUser(LoginUser loginUser)
        {
            //try
            //{
                fmNote._context.LoginUsers.Add(loginUser);
                fmNote._context.SaveChanges();
                return true;
            //}
            //catch { return false; }
        }
        public static List<LoginUser> getListLogin()
        {
            var loginIds = (from u in fmNote._context.LoginUsers.AsEnumerable()
                            select u).Select(x => new LoginUser
                            {
                                UserID = x.UserID,
                                Username = x.Username,
                                Password = x.Password,
                                FullName = x.FullName,
                                DOB = x.DOB,
                                Gender = x.Gender,
                                PhoneNum = x.PhoneNum
                            }).ToList();
            return loginIds;
        }
        public static LoginUser getLogin(int userid)
        {
            var user = (from u in fmNote._context.LoginUsers
                        where u.UserID == userid
                        select u).ToList();
            if (user.Count == 1) return user[0];
            else return null;
        }
        //get password
        public static string GetPassword(string username, string sdt)
        {
            var user = (from u in fmNote._context.LoginUsers
            where u.Username == username && u.PhoneNum == sdt
            select u.Password).ToList();
            if (user.Count == 1) return user[0];
            else return null;
        }
        public static int GetIdLogin(string username)
        {
            var user = (from u in fmNote._context.LoginUsers
                        where u.Username == username
                        select u.UserID).ToList();
            if (user.Count == 1) return user[0];
            return 0;
        }
        public static List<Note> getListNote(int userId)
        {
            var NoteIds = (from u in fmNote._context.Notes.AsEnumerable()
                            where u.UserID == userId
                            select u).Select(x => new Note
                            {
                                NodeID = x.NodeID,
                                UserID = x.UserID,
                                Tittle = x.Tittle,
                                Body = x.Body,
                                SDate = x.SDate,

                            }).ToList();
            return NoteIds;
        }
        //get node
        public static Note getNote(int userid, String nodeid)
        {
            var node = (from u in fmNote._context.LoginUsers
                        join x in fmNote._context.Notes on u.UserID equals x.UserID
                        where x.NodeID == nodeid && x.NodeID == nodeid
                        select x).ToList();
            if (node.Count == 1)
                return node[0];
            else return null;
        }

        public static ConfigureNote GetConfigureNote(String nodeid)
        {
            var node = (from u in fmNote._context.ConfigureNotes
                        where u.NodeID == nodeid
                        select u).ToList();
            if (node.Count == 1)
                return node[0];
            else return null;
        }
        //save note
        public static bool SaveNote(Note note,ConfigureNote configureNote)
        {
            try
            {
                fmNote._context.Notes.Add(note);
                fmNote._context.ConfigureNotes.Add(configureNote);
                fmNote._context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool SaveDeleteNote(Note note,ConfigureNote configure)
        {
            try
            {
                fmNote._context.Trashes.Add(new Trash() { SDate = note.SDate, Title = note.Tittle, Body = note.Body, UserID = note.UserID, NodeID = note.NodeID, DeDate = DateTime.Now, TrashID = note.NodeID });
                fmNote._context.ConfigureTrashes.Add(new ConfigureTrash() 
                { TrashID = configure.NodeID, 
                  FontTrash = configure.FontNote, SizeTrash = configure.SizeNote, 
                  Boldtxt = configure.Boldtxt, Italictxt = configure.Italictxt, Underlinetxt = configure.Underlinwtxt, Striketxt = configure.Striketxt, Colortxt=configure.Colortxt });
                fmNote._context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //delete note
        public static bool DeleteNote(Note note,ConfigureNote configure)
        {
            try
            {
                fmNote._context.ConfigureNotes.Remove(configure);
                fmNote._context.Notes.Remove(note);
                fmNote._context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //update note
        public static bool UpdateNote(Note note,ConfigureNote configure)
        {
            try
            {
                fmNote._context.Notes.AddOrUpdate(note);
                fmNote._context.ConfigureNotes.AddOrUpdate(configure);
                fmNote._context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //trash
        public static List<Trash> getListTrash(int userID)
        {
            var TrashIds = (from u in fmNote._context.Trashes.AsEnumerable()
                           where u.UserID == userID
                           select u).Select(x => new Trash
                           {
                               Body = x.Body,
                               UserID=x.UserID,
                               SDate=x.SDate,
                               DeDate=x.DeDate,
                               Title=x.Title,
                               TrashID=x.TrashID,
                               NodeID=x.NodeID
                           }).ToList();
            return TrashIds;
        }
        public static Trash getTrash(int userid, String nodeid)
        {
            var node = (from u in fmNote._context.LoginUsers
                        join x in fmNote._context.Trashes on u.UserID equals x.UserID
                        where x.NodeID == nodeid && x.NodeID == nodeid
                        select x).ToList();
            if (node.Count == 1)
                return node[0];
            else return null;
        }
        public static ConfigureTrash GetConfigureTrash(string trashID)
        {
            var node = (from u in fmNote._context.ConfigureTrashes
                        where u.TrashID==trashID
                        select u).ToList();
            if (node.Count == 1)
                return node[0];
            else return null;
        }
        public static bool DeleteTrash(Trash note, ConfigureTrash configure)
        {
            try
            {
                fmNote._context.ConfigureTrashes.Remove(configure);
                fmNote._context.Trashes.Remove(note);
                fmNote._context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool SaveDeleteTrash(Trash note, ConfigureTrash configure)
        {
            try
            {
                fmNote._context.Notes.Add(new Note { UserID=note.UserID, NodeID=note.TrashID, Body=note.Body, Tittle=note.Title, SDate= note.SDate});
                fmNote._context.ConfigureNotes.Add(new ConfigureNote
                {
                    NodeID = configure.TrashID,
                    FontNote = configure.FontTrash,
                    SizeNote = configure.SizeTrash,
                    Boldtxt = configure.Boldtxt,
                    Italictxt = configure.Italictxt,
                    Underlinwtxt = configure.Underlinetxt,
                    Striketxt = configure.Striketxt,
                    Colortxt=configure.Colortxt
                });
                fmNote._context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Edit account
        public static bool UpdateAccount(LoginUser login)
        {
            try
            {
            fmNote._context.LoginUsers.AddOrUpdate(login);
                fmNote._context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
