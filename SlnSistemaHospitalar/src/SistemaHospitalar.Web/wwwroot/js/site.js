$(document).ready(() => {
    const tooltipTriggerList = document.querySelectorAll('[data-bs-toggle="tooltip"]');
    const tooltipList = [...tooltipTriggerList].map(tooltipTriggerEl => new bootstrap.Tooltip(tooltipTriggerEl));

    console.log(jQuery().jquery);
    $('#table-index').DataTable();

    //puxando api do CEP
    //fazer ajax

});

/* MODAL */
msgModalMessage = (message, origin, callback) => {
    $('#modal-origin').html(origin);
    $('#modal-corpo').html(message);


    $('#btnModalCallback').click(() => callback());

    $('#msgModal').modal('show');
};

closeMsgModalMessage = () => {
    $('#msgModal').modal('hide');
};

/* TOAST */
liveToastMessage = (message, origin) => {
    $('#toast-origin').html(origin);
    $('#toast-body').html(message);
    $('#toast-time').html(new Date().toLocaleTimeString('pt-br', {
        hour12: false,
        hour: "numeric",
        minute: "numeric"
    }));

    const toastLiveMessages = $('#liveToast');
    const toast = new bootstrap.Toast(toastLiveMessages)
    toast.show()
};

/* LISTAR */

const EnderecoIndex = (idPessoa) => {
    
    $.ajax({
        url: `../Enderecos/ListaEndereco/${idPessoa}`,
        dataType: 'html',
        success: (response) => {
            $('#modal-body-address').html(response);
        }
    });

    //$('#').modal('show');
};

/* CREATE */

// Pessoa
const createPessoa = () => {
    $.ajax({
        url: '../Pessoas/Create',
        dataType: 'html',
        success: (response) => {
            $('#modal-body').html(response)
        }
    });
}

const createControllerPessoa = (urlCreate) => {
    var pessoa = {
        nome: $('#nomePessoa').val(),
        sobrenome: $('#sobrenomePessoa').val(),
        email: $('#emailPessoa').val(),
        senha: $('#senhaPessoa').val(),
        telefone: $('#telefonePessoa').val(),
        cpf: $('#cpfPessoa').val(),
        rg: $('#rgPessoa').val(),
        dataNascimento: $('#nascPessoa').val(),
        naturalidade: $('#natPessoa').val(),
        sexo: $('#sexoPessoa').val(),
        perfil: $('#perfilPessoa').val(),
    }


    $.ajax({
        url: urlCreate,
        method: 'POST',
        data: {
            pessoa: pessoa
        },
        success: (resp) => {
            if (resp.code == '200') {
                $('#formModal').modal('hide');
                $('#btn-pessoa').prop('disabled', true);
                liveToastMessage(`Os dados pessoais foram salvados.`, 'Dados Pessoais');
                setTimeout(() => { window.location.reload(); }, 4000);
                
            }
        }

    });
};


//Endereço
const createEndereco = () => {
    $.ajax({
        url: '../Enderecos/Create',
        dataType: 'html',
        success: (resp) => {
            $('#modal-body').html(resp);
        }
    });
}

const createEnderecoPost = () => {
    var endereco = {
        cep: $('#cep').val(),
        rua: $('#rua').val(),
        numero: $('#numero').val(),
        bairro: $('#bairro').val(),
        cidade: $('#cidade').val(),
        uf: $('#uf').val()
    };

    $.ajax({
        url: `../Enderecos/Create`,
        method: 'POST',
        data: {
            endereco: endereco
        },
        success: (resp) => {
            if (resp.code == '200') {
                $('#formModal').modal('hide');
                liveToastMessage(`O Endereço foi adicionado.`, 'Endereco');
                setTimeout(() => { window.location.reload(); }, 4000);
            }
        }
    });


};


/* EDIT */

//Pessoa
const editPessoa = (urlEdit) => {
    //carrega o forms dentro do modal
    let h1 = '<h1 class="modal-title fs-5">Editar Informações Pessoais</h1>'
    $('#modal-title').html(h1);
    $.ajax({
        url: urlEdit,
        dataType: 'html',
        success: (response) => {
            $('#modal-body').html(response)
        }
    });
};

const editControllerPessoa = (idPessoa, urlEdit) => {
    //faz o post pra controller
    var pessoa = {
        id: $('#idEdit').val(),
        nome: $('#nomeEdit').val(),
        sobrenome: $('#sobrenomeEdit').val(),
        email: $('#emailEdit').val(),
        senha: $('#senhaEdit').val(),
        telefone: $('#telefoneEdit').val(),
        cpf: $('#cpfEdit').val(),
        rg: $('#rgEdit').val(),
        dataNascimento: $('#nascEdit').val(),
        naturalidade: $('#natEdit').val(),
        sexo: $('#sexoEdit').val(),
        perfil: $('#perfilEdit').val(),
        createdOn: $('#createdEdit').val(),
    }

    console.log(pessoa);

    $.ajax({
        url: urlEdit,
        method: 'POST',
        data: {
            id: idPessoa,
            pessoa: pessoa
        },
        success: (resp) => {
            if (resp.code == '200') {
                $('#formModal').modal('hide');
                liveToastMessage(`Os dados pessoais foram editados.`, 'Dados Pessoais');
                setTimeout(() => { window.location.reload(); }, 4000);
            }
        }

    });
};



/* DELETE */
const deleteRegistro = (idParam, origin, urlParam) => {
    msgModalMessage(`Deseja realmente excluir o registro ${idParam}?`, origin, () => {
        $.ajax({
            url: urlParam,
            method: 'POST',
            data: {
                id: idParam
            },
            success: (resp) => {
                if (resp.code == '200') {
                    liveToastMessage(`O Registro ${idParam} foi excluído.`, origin);
                    setTimeout(() => { window.location.reload(); }, 4000);
                }
            }
        });
        closeMsgModalMessage();
    });
}