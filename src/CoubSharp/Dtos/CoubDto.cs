using CoubSharp.Dtos.Versions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoubSharp.Dtos
{
    public class CoubDto
    {
        [JsonProperty("flag")]
        public string Flag { get; set; }

        [JsonProperty("abuses")]
        public string Abuses { get; set; }

        [JsonProperty("recoubs_by_users_channels")]
        public string RecoubsByUsersChannels { get; set; }

        [JsonProperty("recoub")]
        public string Recoub { get; set; }

        [JsonProperty("like")]
        public string Like { get; set; }

        [JsonProperty("audio_file_url")]
        public string AudioFileUrl { get; set; }

        [JsonProperty("in_my_best2015")]
        public bool InMyBest2015 { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("permalink")]
        public string Permalink { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("visibility_type")]
        public string VisibilityType { get; set; }

        [JsonProperty("original_visibility_type")]
        public string OriginalVisibilityType { get; set; }

        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }

        [JsonProperty("is_done")]
        public bool? IsDone { get; set; }

        [JsonProperty("views_count")]
        public int? ViewsCount { get; set; }

        [JsonProperty("cotd")]
        public bool? CoubOfTheDay { get; set; }

        [JsonProperty("cotd_at")]
        public DateTimeOffset? CoubOfTheDayAt { get; set; }

        [JsonProperty("published")]
        public bool Published { get; set; }

        [JsonProperty("published_at")]
        public DateTimeOffset? PublishedAt { get; set; }

        [JsonProperty("reversed")]
        public bool? Reversed { get; set; }

        [JsonProperty("from_editor_v2")]
        public bool? FormEditorV2 { get; set; }

        [JsonProperty("is_editable")]
        public bool? IsEditable { get; set; }

        [JsonProperty("original_sound")]
        public bool? OriginalSound { get; set; }

        [JsonProperty("has_sound")]
        public bool? HasSound { get; set; }

        [JsonProperty("recoub_to")]
        public long? RecoubTo { get; set; }

        [JsonProperty("recoubs_count")]
        public int? RecoubsCount { get; set; }

        [JsonProperty("remixes_count")]
        public int? RemixesCount { get; set; }

        [JsonProperty("likes_count")]
        public int? LikesCount { get; set; }

        [JsonProperty("raw_video_id")]
        public long? RawVideoId { get; set; }

        [JsonProperty("uploaded_by_ios_app")]
        public bool? UploadedByIosApp { get; set; }

        [JsonProperty("uploaded_by_android_app")]
        public bool? UploadedByAndroidApp { get; set; }

        [JsonProperty("raw_video_thumbnail_url")]
        public string RawVideoThumbnailUrl { get; set; }

        [JsonProperty("raw_video_title")]
        public string RawVideoTitle { get; set; }

        [JsonProperty("video_block_banned")]
        public bool? VideoBlockBanned { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("promo_winner")]
        public bool? PromoWinner { get; set; }

        [JsonProperty("promo_winner_recoubers")]
        public string PromoWinnerRecoubers { get; set; }

        //[JsonProperty("editorial_info")]
        //public string EditorialIndo { get; set; }

        [JsonProperty("promo_hint")]
        public string PromoHint { get; set; }

        [JsonProperty("promo_data")]
        public string PromoData { get; set; }

        [JsonProperty("audio_copyright_claim")]
        public string AudioCopyrightClaim { get; set; }

        [JsonProperty("ads_disabled")]
        public bool? AdsDisabled { get; set; }

        [JsonProperty("file_versions")]
        public FileVersionsDto FileVersions { get; set; }

        [JsonProperty("tags")]
        public IEnumerable<TagDto> Tags { get; set; }

        [JsonProperty("categories")]
        public IEnumerable<CategoryDto> Categories { get; set; }

        [JsonProperty("image_versions")]
        public ImageVersionsDto ImageVersions { get; set; }

        [JsonProperty("channel")]
        public ChannelDto Channel { get; set; }

        [JsonProperty("audio_versions")]
        public AudioVersionsDto AudioVersions { get; set; }

        [JsonProperty("flv_audio_versions")]
        public FlvAudioVersionsDto FlvAudioVersions { get; set; }

        [JsonProperty("first_frame_versions")]
        public FirstFrameVersionsDto FirstFrameVersions { get; set; }
        [JsonProperty("dimensions")]
        public DimensionsDto Dimensions { get; set; }

        [JsonProperty("age_restricted")]
        public bool? AgeRestricted { get; set; }

        [JsonProperty("age_restricted_by_admin")]
        public bool? AgeRestrictedByAdmin { get; set; }

        [JsonProperty("not_safe_for_work")]
        public bool? NotSafeForWork { get; set; }

        [JsonProperty("allow_reuse")]
        public bool? AllowReuse { get; set; }

        [JsonProperty("banned")]
        public bool? Banned { get; set; }

        [JsonProperty("external_download")]
        public ExternalDownloadDto ExternalDownload { get; set; }

        [JsonProperty("picture")]
        public string Picture { get; set; }

        [JsonProperty("timeline_picture")]
        public string TimelinePicture { get; set; }

        [JsonProperty("small_picture")]
        public string SmallPicture { get; set; }
        [JsonProperty("percent_done")]
        public int? PercentDone { get; set; }

        [JsonProperty("media_blocks")]
        public MediaBlocksDto MediaBlocks { get; set; }
    }
}
