window.BlazorDownloadFile = (fileName, contentType, data) => {
    // Crear un objeto Blob con los datos del archivo PDF
    const blob = new Blob([data], { type: contentType });

    // Verificar si el navegador admite la API de descarga
    if (navigator.msSaveBlob) {
        // IE y Microsoft Edge
        navigator.msSaveBlob(blob, fileName);
    } else {
        // Otros navegadores
        const link = document.createElement('a');
        link.href = URL.createObjectURL(blob);
        link.download = fileName;
        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);
    }
};

window.saveAsFile = function (fileName, contentType, data) {
    var blob = new Blob([data], { type: contentType });

    if (navigator.msSaveBlob) {
        // Para Internet Explorer y Edge
        navigator.msSaveBlob(blob, fileName);
    } else {
        // Para otros navegadores
        var link = document.createElement("a");
        if (link.download !== undefined) {
            var url = URL.createObjectURL(blob);
            link.setAttribute("href", url);
            link.setAttribute("download", fileName);
            link.style.visibility = 'hidden';
            document.body.appendChild(link);
            link.click();
            document.body.removeChild(link);
        }
    }
};

window.print;
