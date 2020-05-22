using MyBackEnd.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBackEnd.Bussiness.Conctants
{
    public static class Messages
    {
        //Product
        public static string SuccessProductAdded { get; set; } = "Ürün başarıyla eklendi";
        public static string SuccessProductUpdated { get; set; } = "Ürün başarıyla güncellendi";
        public static string SuccessProductDeleted { get; set; } = "Ürün başarıyla silindi";
        public static string AlreadyProduct { get; set; } = "Ürün ismiyle katıt bulundu.İsmi lütfen değiştiriniz";
        //Category
        public static string SuccessCategoryAdded { get; set; } = "Kategori başarıyla eklendi";
        public static string SuccessCategoryUpdated { get; set; } = "Kategori başarıyla güncellendi";
        public static string SuccessCategoryDeleted { get; set; } = "Kategori başarıyla silindi";
        
        //User
        public static string SuccessUserAdded { get; set; } = "Kullanıcı başarıyla eklendi";
        public static string SuccessUserUpdated { get; set; } = "Kullanıcı başarıyla güncellendi";
        public static string SuccessUserDeleted { get; set; } = "Kullanıcı başarıyla silindi";
        public static string UserNotFound { get; set; } = "Kullanıcı bulunamadı";
        public static string UserPasswordError { get; set; } = "Parola hatalı";
        public static string SuccessLogin { get; set; } = "Başarıyla Giriş Yapıldı";
        public static string UserAlready { get; set; } = "Kullanıcı mevcut";
        
        //Auth Service
        public static string AccessTokenCreater { get; set; } = "Access Token oluşturuldu";
        public static string AuthDenied { get; set; } = "Yetkiniz yok";

        //Validation
        public static string ProductName { get; set; } = "Ürün ismi boş olamaz";
    }
}
