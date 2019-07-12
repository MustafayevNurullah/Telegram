using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telegram.Entity
{
  public  class ClientEntity
    {
        public int Id { get; set; }
        public string SenderMessage { get; set; }
        public string SentMessage { get; set; }
        public string SentImage { get; set; }
        public string SenderImage { get; set; }
    }
}
