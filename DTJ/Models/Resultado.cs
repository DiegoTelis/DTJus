﻿namespace DTJ.Models;

public class Resultado()
{
    public bool ok { get; set; }
    public Result[] result { get; set; }
}
public class Result()
{
    public int update_id { get; set; }
    public Message message { get; set; }
}

public class Message()
{
    public int message_id { get; set; }
    public From from { get; set; }
    public Chat chat { get; set; }
    public Int64 date { get; set; }
    public int message_thread_id { get; set; }
    public Message reply_to_message { get; set; }
    public Entity[] entities { get; set; }

    public string text { get; set; }
}
public class Entity()
{
    public int offset { get; set; }
    public int length { get; set; }
    public string type { get; set; }
}
public class From()
{
    public Int64 id { get; set; }
    public bool is_bot { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string username { get; set; }
    public string language_code { get; set; }
}

public class Chat()
{
    public Int64 id { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string username { get; set; }
    public string type { get; set; }


}
