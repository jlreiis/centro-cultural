import React, { useState, useEffect}  from 'react';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import axios from 'axios';
import {Modal, ModalBody, ModalFooter, ModalHeader} from 'reactstrap';
import logoCadastro from './assets/cadastro.png';

function App() {

  const baseUrl="https://localhost:44380/api/Aluno";
  const [data, setData]=useState([]);

  const [modalEditar, setModalEditar]=useState(false);
  const [modalIncluir, setModalIncluir]=useState(false);
  const [modalExcluir, setModalExcluir]=useState(false);

  const [alunoSelecionado, setAlunoSelecionado]=useState({
    id:'',
    nomeAluno:'',
    idade:'',
    nomeResponsavel:'',
    rg:'',
    cpf:'',
    dtentrada: new Date()
  })

  const handleChange=e=>{
    const {name, value}=e.target;
    setAlunoSelecionado({
      ...alunoSelecionado, 
      [name]: value
    });
    console.log(alunoSelecionado);
  }

  //-----modal controle do estado 
  const abrirFecharModalIncluir=()=>{
    setModalIncluir(!modalIncluir);
  }

  const abrirFecharModalEditar=()=>{
    setModalEditar(!modalEditar);
  }

   const abrirFecharModalExcluir=()=>{
    setModalExcluir(!modalExcluir);
  }

  const pedidoGet=async()=>{
    await axios.get("https://localhost:44380/api/Aluno/todosalunos")
    .then(response=>{
     setData(response.data);
}).catch(error=>{
  console.log(error);
})
}

  const pedidoPost=async()=>{
    delete alunoSelecionado.id;
    alunoSelecionado.idade=parseInt(alunoSelecionado.idade);
      await axios.post(baseUrl, alunoSelecionado)
    .then(response=>{
      setData(data.concat(response.data));
      abrirFecharModalIncluir();
    }).catch(error=>{
      console.log(error);
    })
  }

  const pedidoPut=async()=>{
    alunoSelecionado.idade=parseInt(alunoSelecionado.idade);
    await axios.put("https://localhost:44380/api/Aluno?id="+alunoSelecionado.id, alunoSelecionado)
    .then(response=>{
      var resposta=response.data;
      var dadosAuxiliar=data;
      //eslint-disable-next-line
      dadosAuxiliar.map(aluno=>{
        if(aluno.id===alunoSelecionado.id){
          aluno.nomeAluno=resposta.nomeAluno;
          aluno.idade=resposta.idade;
          aluno.nomeResponsavel=resposta.nomeResponsavel;
          aluno.rg=resposta.rg;
          aluno.cpf=resposta.cpf;          
        }
      });
      abrirFecharModalEditar();
    }).catch(error=>{
      console.log(error);
    })
  }

  const pedidoDelete=async()=>{
    await axios.delete(baseUrl+"/"+alunoSelecionado.id)
    .then(response=>{
     setData(data.filter(aluno=>aluno.id!==response.data));
      abrirFecharModalExcluir();
    }).catch(error=>{
      console.log(error);
    })
  }

  const selecionarAluno=(aluno, caso)=>{
    setAlunoSelecionado(aluno);
      (caso==="Editar")?
        abrirFecharModalEditar(): abrirFecharModalExcluir();
  }

  useEffect(()=>{
    pedidoGet();
  })

  return (
    <div className="aluno-container">
       <br/>
       <h2>Centro Cultural Relicário</h2>
       <br/><br/>
       <h3>Cadastro de Alunos</h3>
      <header>
        <img src={logoCadastro} alt="Cadastro" />
        <button onClick={()=>abrirFecharModalIncluir()} className="btn btn-success">Incluir Novo Aluno</button>
       </header>
      <table className="table table-bordered" >
        <thead>
          <tr>
            <th>Id</th>
            <th>Nome do Aluno</th>
            <th>Nome Responsável</th>
            <th>Idade</th>
            <th>RG</th>
            <th>CPF</th>
          </tr>
        </thead>
        <tbody>
          {data.map(aluno=>(
            <tr key={aluno.id}>
              <td>{aluno.id}</td>
              <td>{aluno.nomeAluno}</td>
              <td>{aluno.nomeResponsavel}</td>
              <td>{aluno.idade}</td>
              <td>{aluno.rg}</td>
              <td>{aluno.cpf}</td>
              <td>
              <button className="btn btn-primary" onClick={()=>selecionarAluno(aluno, "Editar")}>Editar</button> {"  "}
              <button className="btn btn-danger" onClick={()=>selecionarAluno(aluno, "Excluir")}>Excluir</button>
              </td>
              </tr>
          ))}
        </tbody>
      </table>
      
      <Modal isOpen={modalIncluir}>
      <ModalHeader>Incluir Alunos</ModalHeader>
      <ModalBody>
        <div className="form-group">
          <label>Nome do Aluno: </label>
          <br />
          <input type="text" className="form-control" name="nomeAluno"  onChange={handleChange}/>
          <br />
          <label>Nome do Responsável: </label>
          <br />
          <input type="text" className="form-control" name="nomeResponsavel" onChange={handleChange}/>
          <br />
          <label>Idade: </label>
          <br />
          <input type="text" className="form-control" name="idade" onChange={handleChange}/>
          <br />
          <label>RG: </label>
          <br />
          <input type="text" className="form-control" name="rg" onChange={handleChange}/>
          <br />
          <label>CPF: </label>
          <br />
          <input type="text" className="form-control" name="cpf" onChange={handleChange}/>
          <br />
        </div>
      </ModalBody>
      <ModalFooter>
        <button className="btn btn-primary" onClick={()=>pedidoPost()}>Incluir</button>{"   "}
        <button className="btn btn-danger" onClick={()=>abrirFecharModalIncluir()}>Cancelar</button>
      </ModalFooter>
    </Modal>

    <Modal isOpen={modalEditar}>
      <ModalHeader>Editar Aluno</ModalHeader>
      <ModalBody>
        <div className="form-group">
        <label>ID: </label>
          <br />
          <input type="text" className="form-control" readOnly value={alunoSelecionado && alunoSelecionado.id}/>
          <br />
          <label>Nome do Aluno: </label>
          <br />
          <input type="text" className="form-control" name="nomeAluno"  onChange={handleChange}/>
          <br />
          <label>Nome do Responsável: </label>
          <br />
          <input type="text" className="form-control" name="nomeResponsavel" onChange={handleChange}/>
          <br />
          <label>Idade: </label>
          <br />
          <input type="text" className="form-control" name="idade" onChange={handleChange}/>
          <br />
          <label>RG: </label>
          <br />
          <input type="text" className="form-control" name="rg" onChange={handleChange}/>
          <br />
          <label>CPF: </label>
          <br />
          <input type="text" className="form-control" name="cpf" onChange={handleChange}/>
          <br />
        </div>
      </ModalBody>
      <ModalFooter>
        <button className="btn btn-primary" onClick={()=>pedidoPut()}>Editar</button>{"   "}
        <button className="btn btn-danger" onClick={()=>abrirFecharModalEditar()}>Cancelar</button>
      </ModalFooter>
    </Modal>

    <Modal isOpen={modalExcluir}>
        <ModalBody>
        Confirma a exclusão deste(a) aluno(a) : {alunoSelecionado && alunoSelecionado.nomeAluno} ?
        </ModalBody>
        <ModalFooter>
          <button className="btn btn-danger" onClick={()=>pedidoDelete()}>
            Sim
          </button>
          <button
            className="btn btn-secondary" onClick={()=>abrirFecharModalExcluir()}
          >
            Não
          </button>
        </ModalFooter>
      </Modal>
      <br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/>
          <h6>RA: 2101477</h6>
          <h6>Nome: Júlia Reis de Aguiar</h6>
          <h6>5ºSemestre-ADS</h6>
    </div>
  );
}

export default App;
