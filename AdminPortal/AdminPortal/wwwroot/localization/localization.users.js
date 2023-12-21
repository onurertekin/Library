var localization = {
    "notify.UserCreated": {
        "tr-TR": "Kullanıcı Oluşturuldu",
        "en-US": "User Created"
    },
    "notify.UserUpdated": {
        "tr-TR": "Kullanıcı Güncellendi",
        "en-US": "User Updated"
    },
    "notify.UserDeleted": {
        "tr-TR": "Kullanıcı Silindi",
        "en-US": "User Deleted"
    },
    "notify.UserActivated": {
        "tr-TR": "Kullanıcı Aktifleştirildi",
        "en-US": "User Activated"
    },
    "notify.UserDeactivated": {
        "tr-TR": "Kullanıcı Pasifleştirildi",
        "en-US": "User Deactivated"
    },
    "notify.UserRolesUpdated": {
        "tr-TR": "Kullanıcının Rolleri Güncellendi",
        "en-US": "User Roles Updated"
    },
    "table.header.user": {
        "tr-TR": "Kullanıcı",
        "en-US": "User"
    },
    "table.header.name": {
        "tr-TR": "Adı",
        "en-US": "Name"
    },
    "table.header.createdOn": {
        "tr-TR": "Oluşturulma Tarihi",
        "en-US": "Created On"
    },
    "table.header.updatedOn": {
        "tr-TR": "Güncelleme Tarihi",
        "en-US": "Updated On"
    },
    "table.header.status": {
        "tr-TR": "Durum",
        "en-US": "Status"
    }
};

function localize(key) {
    var result = "";

    if (localization[key] !== undefined)
        result = localization[key][currentLanguageCode];

    if (result === "" && commonLocalization[key] !== undefined) {
        result = commonLocalization[key][currentLanguageCode];
    }

    return result;
}
