


//Check Image File
function checkImagefile(_filepath) {

    var file = getNameFromPath(_filepath[0].name);
    if (file != null) {
        var extension = file.substr((file.lastIndexOf('.') + 1)).toLowerCase();
        //alert(extension);
        switch (extension) {
            case 'gif':
                flag = true;
                break;
            case 'jpeg':
                flag = true;
                break;
            case 'png':
                flag = true;
                break;
            case 'gif':
                flag = true;
                break;
            case 'jpg':
                flag = true;
                break;
            case 'bmp':
                flag = true;
                break;
            default:
                flag = false;
        }
    }
    if (flag == false) {
        alert("You can upload only .jpg/.jpeg/.png/.bmp/.gif extension file");
        $("#SaveImage").val('');
        return false;
    }
    else {
        if (file != null) {
            var maxfilesize = 1;

            var size = GetFileSize(_filepath[0].size);
            if (size > maxfilesize) {
                alert("You can upload file up to " + maxfilesize + " MB");
                return false;
            }
            return true;
        }
    }
    return true;
}


//get file size
function GetFileSize(filesize) {
    try {
        var fileSize = 0;
        //for FF, Safari, Opeara and Others
        fileSize = filesize / 1024000; //size in mb
        return fileSize;
    }
    catch (e) {
        alert("Error is :" + e);
    }
}

//get file path from client system
function getNameFromPath(strFilepath) {
    var objRE = new RegExp(/([^\/\\]+)$/);
    var strName = objRE.exec(strFilepath);

    if (strName == null) {
        return null;
    }
    else {
        return strName[0];
    }
}

function checkfile() {
    var file = getNameFromPath($("#FILE_PATH").val());
    if (file != null) {
        var extension = file.substr((file.lastIndexOf('.') + 1)).toLowerCase();

        // alert(extension);
        switch (extension) {
            case 'doc':
                flag = true;
                break;
            case 'bmp':
                flag = true;
                break;
            case 'docx':
                flag = true;
                break;
            case 'jpeg':
                flag = true;
                break;
            case 'png':
                flag = true;
                break;
            case 'gif':
                flag = true;
                break;
            case 'jpg':
                flag = true;
                break;
            case 'pdf':
                flag = true;
                break;
            default:
                flag = false;
        }
    }
    if (flag == false) {
        $("#FILE_PATH").val('');
        alert("You can upload only .doc/.docx/.jpg/.jpeg/.png/.bmp/.pdf extension file");
        return false;
    }
    else {
        if (file != null) {
            var maxfilesize = 1;

            var size = GetFileSize('FILE_PATH');
            if (size > maxfilesize) {
                alert("You can upload file up to " + maxfilesize + " MB");
                return false;
            }
        }
    }
}

$(function () {
    $("#FILE_PATH").change(function () {
        checkfile();
    });
});