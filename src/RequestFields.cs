using System;
using System.Collections.Generic;
using System.Text;

public class RequestFields : Dictionary<string, object> {

    public class JSONString
    {
        private String json = "";

        public JSONString(String json)
        {
            this.json = json;
        }

        public override string ToString()
        {
            return json;
        }

    }

};
    