﻿using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using VkToolkit.Enum;
using VkToolkit.Model;
using VkToolkit.Utils;

namespace VkToolkit
{
    public class Friends
    {
        private readonly VkApi _vk;

        public Friends(VkApi vk)
        {
            _vk = vk;
        }

        public IEnumerable<Profile> Get(int uid, ProfileFields fields = null, int? count = null, int? offset = null, Order order = null)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            var values = new Dictionary<string, string>();
            values.Add("uid", uid + "");
            if (fields != null)
                values.Add("fields", fields.ToString());
            if (count.HasValue && count.Value > 0)
                values.Add("count", count.Value + "");
            if (offset.HasValue && offset.Value > 0)
                values.Add("offset", offset.Value + "");
            if (order != null)
                values.Add("order", order.ToString());

            string url = _vk.GetApiUrl("friends.get", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            var response = (JArray) obj["response"];

            if (response.Count > 0 && response[0] is JValue)
            {
                return response.Select(id => new Profile {Uid = (int) id}).ToList();
            }

            return response.Select(p => Utilities.GetProfileFromJObject((JObject) p)).ToList();
        }

        public IEnumerable<Profile> GetAppUsers()
        {
            _vk.IfAccessTokenNotDefinedThrowException();
            throw new NotImplementedException();
        }

        public IEnumerable<Profile> GetOnline()
        {
            _vk.IfAccessTokenNotDefinedThrowException();
            throw new NotImplementedException();
        }

        public IEnumerable<Profile> GetMutual()
        {
            _vk.IfAccessTokenNotDefinedThrowException();
            throw new NotImplementedException();
        }


    }
}