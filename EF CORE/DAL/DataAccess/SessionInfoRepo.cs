using DAL.Models;
using DAL.Models.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DAL.DataAccess
{
    public class SessionInfoRepo : ISessionInfoRepo
    {
        private readonly EventDbContext _context;

        public SessionInfoRepo(EventDbContext context)
        {
            _context = context;
        }

        public SessionInfo AddSession(SessionInfo session)
        {
            _context.SessionInfos.Add(session);
            _context.SaveChanges();
            return session;
        }

        public SessionInfo UpdateSession(SessionInfo session)
        {
            _context.SessionInfos.Update(session);
            _context.SaveChanges();
            return session;
        }

        public SessionInfo DeleteSession(SessionInfo session)
        {
            _context.SessionInfos.Remove(session);
            _context.SaveChanges();
            return session;
        }

        public SessionInfo GetSessionById(int sessionId)
        {
            return _context.SessionInfos.Find(sessionId);
        }

        public List<SessionInfo> GetSessionsByEventId(int eventId)
        {
            return _context.SessionInfos.Where(s => s.EventId == eventId).ToList();
        }

        public List<SessionInfo> GetAllSessions()
        {
            return _context.SessionInfos.ToList();
        }
    }
}
