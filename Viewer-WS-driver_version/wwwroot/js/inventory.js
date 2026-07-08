function GetPCByFileVersion(fileVersion) {
    const tabl = document.getElementById('tbl-version-by-pc');
    const tblBody = document.getElementById('tbl-version-by-pc-body');

    // Запрос к хэндлеру Razor Page
    const url = `?handler=PCByFileVersion&version=${encodeURIComponent(fileVersion)}`;

    // Очищаем старые строки
    tblBody.innerHTML = '';

    fetch(url)
        .then(response => {
            if (!response.ok)
                throw new Error(`Ошибка сервера: ${response.status}`);
            return response.json(); // Просто возвращаем промис парсинга JSON
        })
        .then((data) => {
            // Проверяем, что данные пришли и это массив, который не пуст
            if (data && data.length > 0) {
                data.forEach((row) => {
                    const newRow = `<tr>
                                        <td>${row.computerName}</td>
                                        <td>${row.checkDate}</td>
                                        <td>${row.fileVersion}</td>
                                    </tr>`;

                    tblBody.insertAdjacentHTML("beforeend", newRow);
                });

                // Показываем таблицу (один раз после цикла)
                tabl.style.display = 'table';
            } else {
                console.log("Данные по этой версии отсутствуют");
                tabl.style.display = 'none'; // Скрываем, если пусто
            }
        })
        .catch(error => {
            console.error("Ошибка при выполнении fetch-запроса:", error);
        });
}