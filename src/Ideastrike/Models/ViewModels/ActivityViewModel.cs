﻿using System.Text.RegularExpressions;
using System.Web;
using DanTup.Web;
using Ideastrike.Helpers;

namespace Ideastrike.Models.ViewModels
{
    public class ActivityViewModel
    {
        public ActivityViewModel(Activity activity)
        {
            FriendlyTime = activity.Time.ToFriendly();

            var comment = activity as Comment;
            if (comment != null)
            {
                Text = MarkdownHelper.Markdown(comment.Text.ConvertingLinksToMarkdownUrls());
                // TODO: not hard code these
                Author = activity.User.UserName;
                GravatarUrl = (string.IsNullOrEmpty(activity.User.AvatarUrl)) ? activity.User.Email.ToGravatarUrl(40) : activity.User.AvatarUrl;
            }
        }

        public IHtmlString FriendlyTime { get; private set; }

        public IHtmlString Text { get; private set; }
        public string Author { get; private set; }
        public string GravatarUrl { get; private set; }
    }
}