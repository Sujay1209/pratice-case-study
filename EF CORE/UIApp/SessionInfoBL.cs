using DAL.Models;
using DAL.Models.DAL.Models;
using System.Collections.Generic;

namespace DAL.DataAccess
{
    public class SessionInfoBL
    {
        private readonly ISessionInfoRepo _repo;

        public SessionInfoBL(ISessionInfoRepo repo)
        {
            _repo = repo;
        }

        public SessionInfo AddSession(SessionInfo session) => _repo.AddSession(session);
        public SessionInfo UpdateSession(SessionInfo session) => _repo.UpdateSession(session);
        public SessionInfo DeleteSession(SessionInfo session) => _repo.DeleteSession(session);

        public void DeleteSession(int sessionId)
        {
            var session = _repo.GetSessionById(sessionId);
            if (session != null)
            {
                _repo.DeleteSession(session);
            }
        }

        public SessionInfo GetSessionById(int id) => _repo.GetSessionById(id);
        public List<SessionInfo> GetSessionsByEvent(int eventId) => _repo.GetSessionsByEventId(eventId);
        public List<SessionInfo> GetAllSessions() => _repo.GetAllSessions();
    }
}
