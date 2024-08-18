using System.Data;

namespace KeyStoneEmployee_Dappar.InterFace
{
    public interface IKHTConnectionFactary
    {
        IDbConnection GetHotal();
    }
}
