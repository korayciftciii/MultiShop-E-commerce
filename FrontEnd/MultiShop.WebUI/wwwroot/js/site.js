$(document).ready(function () {
    // CreatedAt tarihini inputa yaz
    const now = new Date().toISOString();
    $('#CreatedAt').val(now);

    $('#reviewForm').submit(function (e) {
        e.preventDefault();

        const token = $('input[name="__RequestVerificationToken"]').val(); // AntiForgeryToken

        const formData = {
            CreatedAt: $('#CreatedAt').val(),
            ProductId: $('input[name="ProductId"]').val(),
            Rating: $('input[name="Rating"]:checked').val(),
            CommentContent: $('textarea[name="CommentContent"]').val(),
            FullName: $('input[name="FullName"]').val(),
            Email: $('input[name="Email"]').val()
        };

        $.ajax({
            type: 'POST',
            url: '/ProductList/AddReview',
            data: formData,
            headers: {
                'RequestVerificationToken': token
            },
            success: function (response) {
                // Form sıfırla
                $('#reviewForm')[0].reset();

                // Yeni yorum bilgileri
                const createdAt = new Date().toLocaleString('tr-TR');
                const rating = formData.Rating;
                let starsHtml = '';
                for (let i = 0; i < rating; i++) {
                    starsHtml += '<i class="fas fa-star"></i>';
                }

                const newCommentHtml = `
                    <div class="media mb-4">
                        <img src="/multishop-1.0.0/img/userIcon.png" alt="Image" class="img-fluid mr-3 mt-1" style="width: 45px;">
                        <div class="media-body">
                            <h6>${formData.FullName}<small> - <i>${createdAt}</i></small></h6>
                            <div class="text-primary mb-2">
                                ${starsHtml}
                            </div>
                            <p>${formData.CommentContent}</p>
                        </div>
                    </div>
                `;

                $('#comment-list').append(newCommentHtml);

                // Yorum sayısını güncelle
                const countSpan = $('#comment-count');
                countSpan.text(parseInt(countSpan.text()) + 1);
            },
            error: function (xhr) {
                console.log("Yorum gönderilirken bir hata oluştu.");
            }
        });
    });
});
