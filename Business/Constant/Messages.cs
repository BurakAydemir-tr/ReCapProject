using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constant
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi.";
        public static string CarNameInvalid = "Araba ismi geçersiz.";
        public static string CarsListed = "Arabalar listelendi.";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ReturnDateNull="Araç kirada! Kiralanamaz";
        public static string RentalCar="Araç kiralandı.";
        public static string AuthorizationDenied="Yetkiniz yok.";
        public static string UserRegistered="Kayıt oldu";
        public static string UserNotFound ="Kullanıcı bulunamadı";
        public static string PasswordError ="Parola hatası";
        public static string SuccessfulLogin="Başarılı giriş";
        public static string UserAlreadyExists="Kullanıcı mevcut";
        public static string AccessTokenCreated="Token oluşturuldu";
    }
}
