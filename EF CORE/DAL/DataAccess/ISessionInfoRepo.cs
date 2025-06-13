using DAL.Models;
using DAL.Models.DAL.Models;
using System.Collections.Generic;

namespace DAL.DataAccess
{
    public interface ISessionInfoRepo
    {
        SessionInfo AddSession(SessionInfo session);
        SessionInfo UpdateSession(SessionInfo session);
        SessionInfo DeleteSession(SessionInfo session);
        SessionInfo GetSessionById(int sessionId);
        List<SessionInfo> GetSessionsByEventId(int eventId);
        List<SessionInfo> GetAllSessions();
    }
}
