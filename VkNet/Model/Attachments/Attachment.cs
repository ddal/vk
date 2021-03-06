﻿using System;
using VkNet.Exception;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
    /// Информация о медиавложении в записи.
    /// См. описание <see href="http://vk.com/dev/attachments_w"/>. 
    /// </summary>
    public class Attachment
    {
        #region Поля

        /// <summary>
        /// Фотография из альбома или фотография, загруженная напрямую с компьютера пользователя.
        /// </summary>
        private Photo Photo { get; set; }

        /// <summary>
        /// Видеозапись.
        /// </summary>
        private Video Video { get; set; }

        /// <summary>
        /// Аудиозапись.
        /// </summary>
        private Audio Audio { get; set; }

        /// <summary>
        /// Документ.
        /// </summary>
        private Document Document { get; set; }

        /// <summary>
        /// Документ.
        /// </summary>
        private Graffiti Graffiti { get; set; }

        /// <summary>
        /// Ссылка на Web-страницу.
        /// </summary>
        private Link Link { get; set; }

        /// <summary>
        /// Заметка.
        /// </summary>
        private Note Note { get; set; }

        /// <summary>
        /// Контент приложения.
        /// </summary>
        private ApplicationContent ApplicationContent { get; set; }

        /// <summary>
        /// Опрос.
        /// </summary>
        private Poll Poll { get; set; }

        /// <summary>
        /// Wiki страница.
        /// </summary>
        private Page Page { get; set; }

        /// <summary>
        /// Альбом с фотографиями.
        /// </summary>
        private Album Album { get; set; }

	    private PhotosList PhotosList;

        private Wall Wall { get; set; }

        private Sticker Sticker { get; set; }

        #endregion

        /// <summary>
        /// Экземпляр самого прикрепления.
        /// </summary>
        public object Instance
        {
            get
            {
                if (Type == typeof(Photo))
                    return Photo;
                if (Type == typeof(Video))
                    return Video;
                if (Type == typeof(Audio))
                    return Audio;
                if (Type == typeof(Document))
                    return Document;
                if (Type == typeof(Graffiti))
                    return Graffiti;
                if (Type == typeof(Link))
                    return Link;
                if (Type == typeof(Note))
                    return Note;
                if (Type == typeof(ApplicationContent))
                    return ApplicationContent;
                if (Type == typeof(Poll))
                    return Poll;
                if (Type == typeof(Page))
                    return Page;
                if (Type == typeof(Album))
                    return Album;
                if (Type == typeof (PhotosList))
                    return PhotosList;
                if (Type == typeof (Wall))
                    return Wall;
                if (Type == typeof (Sticker))
                    return Sticker;

                return null;
            }
        }

        /// <summary>
        /// Информация о типе вложения.
        /// </summary>
        public Type Type { get; set; }

        #region Методы

        internal static Attachment FromJson(VkResponse response)
        {
            // TODO: Complete it later
            var attachment = new Attachment();

            string type = response["type"];
            switch (type)
            {
                case "photo":
                case "posted_photo":
                    attachment.Type = typeof(Photo);
                    attachment.Photo = response[type];
                    break;

                case "video":
                    attachment.Type = typeof(Video);
                    attachment.Video = response["video"];
                    break;

                case "audio":
                    attachment.Type = typeof(Audio);
                    attachment.Audio = response["audio"];
                    break;

                case "doc":
                    attachment.Type = typeof(Document);
                    attachment.Document = response["doc"];
                    break;

                case "graffiti":
                    attachment.Type = typeof(Graffiti);
                    attachment.Graffiti = response["graffiti"];
                    break;

                case "link":
                    attachment.Type = typeof(Link);
                    attachment.Link = response["link"];
                    break;

                case "note":
                    attachment.Type = typeof(Note);
                    attachment.Note = response["note"];
                    break;

                case "app":
                    attachment.Type = typeof(ApplicationContent);
                    attachment.ApplicationContent = response["app"];
                    break;

                case "poll":
                    attachment.Type = typeof(Poll);
                    attachment.Poll = response["poll"];
                    break;

                case "page":
                    attachment.Type = typeof(Page);
                    attachment.Page = response["page"];
                    break;

                case "album":
                    attachment.Type = typeof(Album);
                    attachment.Album = response["album"];
                    break;

                case "photos_list":
                    attachment.Type = typeof (PhotosList);
                    attachment.PhotosList = response["photos_list"];
                    break;

                case "wall":
                    attachment.Type = typeof (Wall);
                    attachment.Wall = response["wall"];
                    break;

                case "sticker":
                    attachment.Type = typeof (Sticker);
                    attachment.Sticker = response["sticker"];
                    break;

                default:
                    throw new InvalidParameterException(string.Format("The type '{0}' of attachment is not defined.", type));
            }

            return attachment;
        }

        #endregion
    }
}