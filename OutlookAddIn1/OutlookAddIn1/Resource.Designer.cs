﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _OutlookAddIn1 {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("_OutlookAddIn1.Resource", typeof(Resource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Icon similar to (Icon).
        /// </summary>
        internal static System.Drawing.Icon _39_48 {
            get {
                object obj = ResourceManager.GetObject("_39_48", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap animatedCircle {
            get {
                object obj = ResourceManager.GetObject("animatedCircle", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Icon similar to (Icon).
        /// </summary>
        internal static System.Drawing.Icon blackfolder {
            get {
                object obj = ResourceManager.GetObject("blackfolder", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE comments
        ///  (
        ///     comment_id        VARCHAR PRIMARY KEY,
        ///     comment           TEXT DEFAULT NULL,
        ///     widget_id         VARCHAR DEFAULT NULL,
        ///     creator           VARCHAR DEFAULT NULL,
        ///     creation_date     VARCHAR DEFAULT NULL,
        ///     modifier          VARCHAR DEFAULT NULL,
        ///     modification_date VARCHAR DEFAULT NULL,
        ///     is_owner          INTEGER DEFAULT 0,
        ///     sync_status       INTEGER DEFAULT 0,
        ///     error_type        INTEGER DEFAULT 0,
        ///     error_code        INTEGER DEFAUL [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string comments {
            get {
                return ResourceManager.GetString("comments", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Icon similar to (Icon).
        /// </summary>
        internal static System.Drawing.Icon connectedicon {
            get {
                object obj = ResourceManager.GetObject("connectedicon", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE contacts(useremail VARCHAR PRIMARY KEY,user_fname VARCHAR DEFAULT NULL,user_lname VARCHAR DEFAULT NULL,company VARCHAR DEFAULT NULL,enterprise_id INTEGER DEFAULT NULL).
        /// </summary>
        internal static string contacts {
            get {
                return ResourceManager.GetString("contacts", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE content_expiry
        ///  (
        ///     id                VARCHAR PRIMARY KEY,
        ///     type              INTEGER DEFAULT 0,
        ///     expiry_date       VARCHAR NOT NULL,
        ///     first_alert_date  VARCHAR NOT NULL,
        ///     second_alert_date VARCHAR NOT NULL,
        ///     sync_status       INTEGER DEFAULT 0,
        ///     error_type        INTEGER DEFAULT 0,
        ///     error_code        INTEGER DEFAULT 0,
        ///     retry_count       INTEGER DEFAULT 0).
        /// </summary>
        internal static string content_expiry {
            get {
                return ResourceManager.GetString("content_expiry", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE createdby(createdby_id VARCHAR PRIMARY KEY,firstName VARCHAR DEFAULT NULL,lastName VARCHAR DEFAULT NULL,email VARCHAR DEFAULT NULL,elementType VARCHAR DEFAULT NULL,elementTypeId VARCHAR DEFAULT NULL).
        /// </summary>
        internal static string createdby {
            get {
                return ResourceManager.GetString("createdby", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Icon similar to (Icon).
        /// </summary>
        internal static System.Drawing.Icon disconnectedicon {
            get {
                object obj = ResourceManager.GetObject("disconnectedicon", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE docs
        ///  (
        ///     doc_id                VARCHAR PRIMARY KEY,
        ///     file_name             TEXT    DEFAULT NULL,
        ///     mime_type             VARCHAR DEFAULT NULL,
        ///     size                  INTEGER DEFAULT 0,
        ///     wit_id                VARCHAR DEFAULT NULL,
        ///     local_path            VARCHAR DEFAULT NULL,
        ///     container_dir_path    VARCHAR DEFAULT NULL
        ///  ).
        /// </summary>
        internal static string docs {
            get {
                return ResourceManager.GetString("docs", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT
        ///or     REPLACE
        ///into   docs
        ///       (
        ///              doc_id ,
        ///              file_name ,
        ///              mime_type ,
        ///              size,
        ///              wit_id ,
        ///              local_path,
        ///              container_dir_path
        ///       )
        ///       VALUES
        ///       (
        ///              @doc_id ,
        ///              @file_name ,
        ///              @mime_type ,
        ///              @size,
        ///              @wit_id ,
        ///              @local_path,
        ///              @container_dir_path
        ///       ).
        /// </summary>
        internal static string docs_insert {
            get {
                return ResourceManager.GetString("docs_insert", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to connect to the remote server..
        /// </summary>
        internal static string ERROR_0 {
            get {
                return ResourceManager.GetString("ERROR_0", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to OK (along with invalid user Ids in the response body).
        /// </summary>
        internal static string ERROR_200 {
            get {
                return ResourceManager.GetString("ERROR_200", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Bad Request.
        /// </summary>
        internal static string ERROR_400 {
            get {
                return ResourceManager.GetString("ERROR_400", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid Username and Password combination. .
        /// </summary>
        internal static string ERROR_BadRequest {
            get {
                return ResourceManager.GetString("ERROR_BadRequest", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Mandatory parameter is missing..
        /// </summary>
        internal static string ERROR_E99_003 {
            get {
                return ResourceManager.GetString("ERROR_E99_003", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE event_records
        ///  (
        ///     id INTEGER PRIMARY KEY ASC,
        ///	 analytics_json BLOB DEFAULT NULL
        ///   ).
        /// </summary>
        internal static string event_records {
            get {
                return ResourceManager.GetString("event_records", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Icon similar to (Icon).
        /// </summary>
        internal static System.Drawing.Icon folder {
            get {
                object obj = ResourceManager.GetObject("folder", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE folders
        ///  (
        ///     id                    VARCHAR PRIMARY KEY,
        ///	 name                  VARCHAR DEFAULT NULL,
        ///     type                  VARCHAR DEFAULT NULL,
        ///     workspace_id          VARCHAR DEFAULT NULL,
        ///     enterprise_id         VARCHAR DEFAULT NULL,
        ///	 folderType            VARCHAR DEFAULT NULL,  
        ///     parentId              VARCHAR DEFAULT NULL,
        ///     children              VARCHAR DEFAULT NULL,
        ///     hasChildren           INTEGER DEFAULT 0,
        ///     updateNumber          INTEGER DEFAULT  [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string folders {
            get {
                return ResourceManager.GetString("folders", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT OR REPLACE INTO folders(id,name,type,workspace_id,enterprise_id,folderType,parentId,children,hasChildren,updateNumber) values (@id,@name,@type,@workspace_id,@enterprise_id,@folderType,@parentId,@children,@hasChildren,@updateNumber).
        /// </summary>
        internal static string folders_insert {
            get {
                return ResourceManager.GetString("folders_insert", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to .
        /// </summary>
        internal static string folders_select {
            get {
                return ResourceManager.GetString("folders_select", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Icon similar to (Icon).
        /// </summary>
        internal static System.Drawing.Icon grayfolder {
            get {
                object obj = ResourceManager.GetObject("grayfolder", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE group_contacts(id INTEGER ASC, group_id VARCHAR NOT NULL, username VARCHAR NOT NULL, from_group_id VARCHAR DEFAULT NULL,sync_status INTEGER DEFAULT 0, error_type INTEGER DEFAULT 0,error_code INTEGER DEFAULT 0,retry_count INTEGER DEFAULT 0, PRIMARY KEY (group_id, username)).
        /// </summary>
        internal static string group_contacts {
            get {
                return ResourceManager.GetString("group_contacts", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE groups(group_id VARCHAR PRIMARY KEY,group_name VARCHAR,workspace INTEGER DEFAULT 0,item_count INTEGER DEFAULT 0,creation_date VARCHAR DEFAULT NULL,modification_date VARCHAR DEFAULT NULL,creator VARCHAR DEFAULT NULL,modifier VARCHAR DEFAULT NULL,company VARCHAR DEFAULT NULL,enterprise_id VARCHAR DEFAULT NULL,creator_id VARCHAR DEFAULT NULL,sync_status INTEGER DEFAULT 0,error_type INTEGER DEFAULT 0,error_code INTEGER DEFAULT 0,retry_count INTEGER DEFAULT 0,valid_users TEXT DEFAULT NULL,invalid_us [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string groups {
            get {
                return ResourceManager.GetString("groups", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Icon similar to (Icon).
        /// </summary>
        internal static System.Drawing.Icon logout {
            get {
                object obj = ResourceManager.GetObject("logout", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE modifiedby(id VARCHAR PRIMARY KEY,firstName VARCHAR DEFAULT NULL,lastName VARCHAR DEFAULT NULL,email VARCHAR DEFAULT NULL,elementType VARCHAR DEFAULT NULL,elementTypeId VARCHAR DEFAULT NULL).
        /// </summary>
        internal static string modifiedby {
            get {
                return ResourceManager.GetString("modifiedby", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE notification_actions(id INTEGER PRIMARY KEY ASC, action_id VARCHAR NOT NULL, notification_id VARCHAR NOT NULL, name VARCHAR DEFAULT NULL, params VARCHAR DEFAULT NULL, api VARCHAR DEFAULT NULL, api_base INTEGER DEFAULT 0,sync_status INTEGER DEFAULT 0,error_type INTEGER DEFAULT 0,error_code INTEGER DEFAULT 0,retry_count INTEGER DEFAULT 0).
        /// </summary>
        internal static string notification_actions {
            get {
                return ResourceManager.GetString("notification_actions", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE notifications(notification_id VARCHAR PRIMARY KEY NOT NULL, message VARCHAR, type INTEGER DEFAULT 0, sender VARCHAR , receiver VARCHAR , obj_id VARCHAR , creation_date VARCHAR , sync_date VARCHAR , is_read INTEGER DEFAULT 0, sync_status INTEGER DEFAULT 0,error_type INTEGER DEFAULT 0,error_code INTEGER DEFAULT 0,retry_count INTEGER DEFAULT 0).
        /// </summary>
        internal static string notifications {
            get {
                return ResourceManager.GetString("notifications", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to OK.
        /// </summary>
        internal static string OK {
            get {
                return ResourceManager.GetString("OK", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE package(package_id VARCHAR PRIMARY KEY,package_name VARCHAR DEFAULT &apos;None&apos;,package_type INTEGER DEFAULT 0,base_package INTEGER DEFAULT 0,package_desc VARCHAR DEFAULT &apos;None&apos;).
        /// </summary>
        internal static string package {
            get {
                return ResourceManager.GetString("package", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE package_feature(packagef__id INTEGER PRIMARY KEY ASC,package_id VARCHAR DEFAULT NULL,feature_id VARCHAR DEFAULT NULL,feature_name VARCHAR DEFAULT NULL,is_enabled INTEGER DEFAULT 0,is_hidden INTEGER DEFAULT 0).
        /// </summary>
        internal static string package_feature {
            get {
                return ResourceManager.GetString("package_feature", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE permission(code VARCHAR PRIMARY KEY,name VARCHAR DEFAULT NULL,description VARCHAR DEFAULT NULL,authority VARCHAR DEFAULT NULL);.
        /// </summary>
        internal static string permission {
            get {
                return ResourceManager.GetString("permission", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Icon similar to (Icon).
        /// </summary>
        internal static System.Drawing.Icon plus {
            get {
                object obj = ResourceManager.GetObject("plus", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Icon similar to (Icon).
        /// </summary>
        internal static System.Drawing.Icon Power {
            get {
                object obj = ResourceManager.GetObject("Power", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Icon similar to (Icon).
        /// </summary>
        internal static System.Drawing.Icon refreshgray {
            get {
                object obj = ResourceManager.GetObject("refreshgray", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Icon similar to (Icon).
        /// </summary>
        internal static System.Drawing.Icon searchIcon {
            get {
                object obj = ResourceManager.GetObject("searchIcon", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap searchImage {
            get {
                object obj = ResourceManager.GetObject("searchImage", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE socialmedia(id VARCHAR PRIMARY KEY,socialMediaType VARCHAR, is_user_oauth_done INTEGER DEFAULT 0,user_oauth_token TEXT DEFAULT NULL,user_oauth_token_expire_in NUMBER DEFAULT 0,user_oauth_token_secret_key TEXT DEFAULT NULL).
        /// </summary>
        internal static string socialmedia {
            get {
                return ResourceManager.GetString("socialmedia", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT OR REPLACE INTO socialmedia(id,socialMediaType,is_user_oauth_done,user_oauth_token,user_oauth_token_expire_in,user_oauth_token_secret_key) values (@id,@socialMediaType,@is_user_oauth_done,@user_oauth_token,@user_oauth_token_expire_in,@user_oauth_token_secret_key).
        /// </summary>
        internal static string socialmedia_insert {
            get {
                return ResourceManager.GetString("socialmedia_insert", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE taggroups(taggroup_id VARCHAR PRIMARY KEY,name VARCHAR,parent_id VARCHAR,parent_name VARCHAR,enterprise_id VARCHAR,source INTEGER DEFAULT 0,status INTEGER DEFAULT 0,workspace INTEGER DEFAULT 0,creation_date VARCHAR DEFAULT NULL,modification_date VARCHAR DEFAULT NULL,creator VARCHAR DEFAULT NULL,modifier VARCHAR DEFAULT NULL,company VARCHAR DEFAULT NULL,permission INTEGER DEFAULT 0,sync_status INTEGER DEFAULT 0,error_type INTEGER DEFAULT 0,error_code INTEGER DEFAULT 0,retry_count INTEGER DEFAULT [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string taggroups {
            get {
                return ResourceManager.GetString("taggroups", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE tags(id VARCHAR PRIMARY KEY,name VARCHAR,parent_id VARCHAR,parent_name VARCHAR,enterprise_id VARCHAR,source INTEGER DEFAULT 0,status INTEGER DEFAULT 0,workspace INTEGER DEFAULT 0,creation_date VARCHAR DEFAULT NULL,modification_date VARCHAR DEFAULT NULL,creator VARCHAR DEFAULT NULL,modifier VARCHAR DEFAULT NULL,company VARCHAR DEFAULT NULL,permission INTEGER DEFAULT 0,sync_status INTEGER DEFAULT 0,error_type INTEGER DEFAULT 0,error_code INTEGER DEFAULT 0,retry_count INTEGER DEFAULT 0).
        /// </summary>
        internal static string tags {
            get {
                return ResourceManager.GetString("tags", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE top_wits(id INTEGER PRIMARY KEY ASC,from_date VARCHAR,to_date VARCHAR,count INTEGER,usage VARCHAR).
        /// </summary>
        internal static string top_wits {
            get {
                return ResourceManager.GetString("top_wits", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE user_defaults(id INTEGER PRIMARY KEY ASC,font_family VARCHAR DEFAULT &apos;Arial&apos;,font_size INTEGER DEFAULT 12,font_color VARCHAR DEFAULT &apos;#000000&apos;,is_useondrag INTEGER DEFAULT 0,font_settings BLOB DEFAULT NULL,desktop_settings BLOB DEFAULT NULL,widget_settings BLOB DEFAULT NULL,sync_status INTEGER DEFAULT 0,error_type INTEGER DEFAULT 0,error_code INTEGER DEFAULT 0,retry_count INTEGER DEFAULT 0).
        /// </summary>
        internal static string user_defaults {
            get {
                return ResourceManager.GetString("user_defaults", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE user_package(id INTEGER PRIMARY KEY ASC,package_attr VARCHAR DEFAULT &apos;None&apos;,package_value VARCHAR DEFAULT &apos;None&apos;).
        /// </summary>
        internal static string user_package {
            get {
                return ResourceManager.GetString("user_package", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE user_profiles(username VARCHAR PRIMARY KEY,user_fname VARCHAR,user_lname VARCHAR,avatar_url VARCHAR,timestamp VARCHAR,company VARCHAR,avatar_file_path VARCHAR).
        /// </summary>
        internal static string user_profiles {
            get {
                return ResourceManager.GetString("user_profiles", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO user_profiles(username,
        ///user_fname,
        ///user_lname,
        ///avatar_url,
        ///timestamp,
        ///company,
        ///avatar_file_path)
        ///VALUES
        ///(@username,
        ///@user_fname,
        ///@user_lname,
        ///@avatar_url,
        ///@timestamp,
        ///@company,
        ///@avatar_file_path).
        /// </summary>
        internal static string user_profiles_insert {
            get {
                return ResourceManager.GetString("user_profiles_insert", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE users(username VARCHAR PRIMARY KEY,user_fname VARCHAR DEFAULT NULL,user_lname VARCHAR DEFAULT NULL,password TEXT,last_login VARCHAR DEFAULT NULL,is_remember_password INTEGER,db_path VARCHAR DEFAULT NULL,user_ticket VARCHAR DEFAULT NULL,avatar_url VARCHAR DEFAULT NULL,last_sync_datetime VARCHAR,avatar_file_path VARCHAR,is_active INTEGER DEFAULT 0,mailtowit_id VARCHAR DEFAULT NULL,enterprise_id VARCHAR DEFAULT NULL).
        /// </summary>
        internal static string users {
            get {
                return ResourceManager.GetString("users", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO users(username,user_fname,user_lname,password,last_login,is_remember_password,db_path,user_ticket,avatar_url,last_sync_datetime,avatar_file_path,is_active,mailtowit_id,enterprise_id) values (@username,@user_fname,@user_lname,@password,@last_login,@is_remember_password,@db_path,@user_ticket,@avatar_url,@last_sync_datetime,@avatar_file_path,@is_active,@mailtowit_id,@enterprise_id).
        /// </summary>
        internal static string users_insert {
            get {
                return ResourceManager.GetString("users_insert", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE userworkspaces(id VARCHAR PRIMARY KEY,name VARCHAR DEFAULT NULL,enterpriseId VARCHAR DEFAULT NULL,sequenceNumber INTEGER,description VARCHAR DEFAULT NULL,createdDate VARCHAR DEFAULT NULL,modifiedDate VARCHAR DEFAULT NULL).
        /// </summary>
        internal static string userworkspaces {
            get {
                return ResourceManager.GetString("userworkspaces", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT OR REPLACE INTO userworkspaces (id ,name ,enterpriseId,sequenceNumber,description ,createdDate ,modifiedDate) values (@id,@name,@enterpriseId,@sequenceNumber,@description ,@createdDate ,@modifiedDate).
        /// </summary>
        internal static string userworkspaces_insert {
            get {
                return ResourceManager.GetString("userworkspaces_insert", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT * from userworkspaces.
        /// </summary>
        internal static string userworkspaces_select {
            get {
                return ResourceManager.GetString("userworkspaces_select", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE wit_attachments
        ///(
        ///id VARCHAR PRIMARY KEY,
        ///file_id VARCHAR NULL, 
        ///wit_id VARCHAR NOT NULL, 
        ///file_name VARCHAR NOT NULL, 
        ///file_mime_type VARCHAR NOT NULL, 
        ///file_association_id VARCHAR NOT NULL, 
        ///seq_number VARCHAR NULL, 
        ///is_inline INTEGER DEFAULT 0, 
        ///source VARCHAR NOT NULL,
        ///extention VARCHAR NOT NULL,
        ///fileSize VARCHAR NULL, 
        ///attachment_type VARCHAR NOT NULL
        ///).
        /// </summary>
        internal static string wit_attachments {
            get {
                return ResourceManager.GetString("wit_attachments", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT OR REPLACE INTO wit_attachments
        ///            (id,
        ///            file_id,
        ///             wit_id,
        ///             file_name,
        ///             file_mime_type,
        ///             file_association_id,
        ///             seq_number,
        ///             is_inline,
        ///             source,
        ///             extention,
        ///             fileSize,
        ///             attachment_type)
        ///VALUES 
        ///            (@id,
        ///             @file_id,
        ///             @wit_id,
        ///             @file_name,
        ///             @file_mime_type,
        ///             @file_association_id,        /// [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string wit_attachments_insert {
            get {
                return ResourceManager.GetString("wit_attachments_insert", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE wit_tags(id INTEGER ASC, tag_id VARCHAR NOT NULL, wit_id VARCHAR NOT NULL, sync_status INTEGER DEFAULT 0, error_type INTEGER DEFAULT 0,error_code INTEGER DEFAULT 0,retry_count INTEGER DEFAULT 0, PRIMARY KEY (tag_id, wit_id)).
        /// </summary>
        internal static string wit_tags {
            get {
                return ResourceManager.GetString("wit_tags", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE wits
        ///  (
        ///     id                VARCHAR PRIMARY KEY,
        ///     name              VARCHAR DEFAULT NULL,
        ///     type              VARCHAR DEFAULT NULL,
        ///     enterprise_id     VARCHAR DEFAULT NULL,
        ///     workspace_id      VARCHAR DEFAULT NULL,
        ///     parent_id         VARCHAR DEFAULT NULL,
        ///     children          VARCHAR DEFAULT NULL,
        ///     haschildren       INTEGER DEFAULT 0,
        ///     updatenumber      INTEGER DEFAULT 0,
        ///     ratingcount       INTEGER DEFAULT 0,
        ///     ratingaggregation INTEGER DEFAULT [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string wits {
            get {
                return ResourceManager.GetString("wits", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT OR REPLACE INTO wits(id ,name ,type ,enterprise_id,workspace_id,parent_id ,children ,hasChildren, updateNumber, ratingCount ,ratingAggregation, desc, content,isFavorite, witType, status, label) 
        ///values (@id ,@name ,@type ,@enterprise_id ,@workspace_id ,@parent_id,@children ,@hasChildren ,@updateNumber ,@ratingCount ,@ratingAggregation ,@desc,@content ,@isFavorite ,@witType ,@status ,@label).
        /// </summary>
        internal static string wits_insert {
            get {
                return ResourceManager.GetString("wits_insert", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE wits_usage(id VARCHAR PRIMARY KEY,text_used INTEGER DEFAULT 0,files_used INTEGER DEFAULT 0,days7_used INTEGER DEFAULT 0,days30_used INTEGER DEFAULT 0,shared_text_used INTEGER DEFAULT 0,shared_files_used INTEGER DEFAULT 0,shared_days7_used INTEGER DEFAULT 0,shared_days30_used INTEGER DEFAULT 0).
        /// </summary>
        internal static string wits_usage {
            get {
                return ResourceManager.GetString("wits_usage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE wits_usagegraphs(id INTEGER PRIMARY KEY,from_date VARCHAR,to_date VARCHAR,step_size VARCHAR,num_data INTEGER,start_offset INTEGER,type VARCHAR).
        /// </summary>
        internal static string wits_usagegraphs {
            get {
                return ResourceManager.GetString("wits_usagegraphs", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE witsusagegraph_data(id INTEGER PRIMARY KEY ASC,graph_id INTEGER,key INTEGER,ttd_personal INTEGER,ttd_shared INTEGER,ttd_enterprise INTEGER,ttd_premium INTEGER,total_wc INTEGER).
        /// </summary>
        internal static string witsusagegraph_data {
            get {
                return ResourceManager.GetString("witsusagegraph_data", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap wp {
            get {
                object obj = ResourceManager.GetObject("wp", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap wpImage {
            get {
                object obj = ResourceManager.GetObject("wpImage", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Icon similar to (Icon).
        /// </summary>
        internal static System.Drawing.Icon wplogo {
            get {
                object obj = ResourceManager.GetObject("wplogo", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Icon similar to (Icon).
        /// </summary>
        internal static System.Drawing.Icon ws {
            get {
                object obj = ResourceManager.GetObject("ws", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
    }
}
