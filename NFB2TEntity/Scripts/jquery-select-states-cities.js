$(function () {
    $(document).ready(function () {

        if ($('select[name*="codUF"]').val() == '') {
            $('[codCidade] option').filter(function () {
                return $(this).val() == "";
            }).attr('selected', true);
            blockCities();
        }

        $('select[name*="codUF"]').change(function () {
            if ($(this).val() != '') {
                idState = $(this).val();
                unblockCities();
                $.getJSON("/City/AjaxCities", { "idState": idState }, updateCities);
            } else {
                blockCities();
            }
            
        });

        updateCities = function (cities) {
            $('select[name*="codCidade"]').empty();
            $.each(cities, function (index, city) {
                $('select[name*="codCidade"]').append('<option value="' + city.codCidade + '">' + city.noCidade + '</option>');
            })
            $('select[name*="codCidade"]').selectpicker('refresh');
        }

        function blockCities(){
            $('select[name*="codCidade"]').empty();
            $('select[name*="codCidade"]').append('<option value="">Selecione a Cidade</option>');
            $('select[name*="codCidade"]').selectpicker('refresh');
            $('select[name*="codCidade"]').prop('disabled', true);
        }

        function unblockCities() {
            $('select[name*="codCidade"]').prop('disabled', false);
        }

    });
});