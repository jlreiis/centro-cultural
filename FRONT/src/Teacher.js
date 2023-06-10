import React, { useState, useEffect}  from 'react';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import axios from 'axios';
import {Modal, ModalBody, ModalFooter, ModalHeader} from 'reactstrap';
import logoCadastro from './assets/cadastro.png';

function Teacher() {

  const baseUrl="https://localhost:44380/api";
  const [data, setData]=useState([]);
  const [updateData, setUpdateData] = useState(true);

  const [modalEditar, setModalEditar]=useState(false);
  const [modalIncluir, setModalIncluir]=useState(false);
  const [modalExcluir, setModalExcluir]=useState(false);

  const [professorSelecionado, setProfessorSelecionado]=useState({
    id:'',
    nomeProfessor:'',
    atvResponsavel:'',

    dtEntrada: new Date()
  })

  const handleChange=e=>{
    const {name, value}=e.target;
    setProfessorSelecionado({
      ...professorSelecionado, 
      [name]: value
    });
    console.log(professorSelecionado);
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
    await axios.get("https://localhost:44380/api/TodosProfessores")
    .then(response=>{
     setData(response.data);
     setUpdateData(true)

}).catch(error=>{
  console.log(error);
})
}

  const pedidoPost=async()=>{
    delete professorSelecionado.id;
      await axios.post(baseUrl,professorSelecionado)
    .then(response=>{
      setData(data.concat(response.data));      
      setUpdateData(true)
      abrirFecharModalIncluir();
    }).catch(error=>{
      console.log(error);
    })
  }

  const pedidoPut=async()=>{
    await axios.put("https://localhost:44380/api?id="+professorSelecionado.id, professorSelecionado)
    .then(response=>{
      var resposta=response.data;
      var dadosAuxiliar=data;
      //eslint-disable-next-line
      dadosAuxiliar.map(professor=>{
        if(professor.id===professorSelecionado.id){
          professor.nomeprofessor=resposta.nomeprofessor;
          professor.atvResponsavel = resposta.atvResponsavel;   
        }
      });
      abrirFecharModalEditar();
            setUpdateData(true)

    }).catch(error=>{
      console.log(error);
    })
  }

  const pedidoDelete=async()=>{
    await axios.delete(baseUrl+"/"+professorSelecionado.id)
    .then(response=>{
     setData(data.filter(professor=>professor.id!==response.data));
      setUpdateData(true)
      abrirFecharModalExcluir();
    }).catch(error=>{
      console.log(error);
    })
  }

  const selecionarProfessor=(professor, caso)=>{
    setProfessorSelecionado(professor);
      (caso==="Editar")?
        abrirFecharModalEditar(): abrirFecharModalExcluir();
  }

  useEffect(()=>{
    if(updateData) {
      pedidoGet();
      setUpdateData(false)
    }
  },[updateData])

  return (
    <div className="aluno-container">
       <br/>
       <h2>Centro Cultural Relicário</h2>
       <br/><br/>
       <h3>Cadastro de Professores</h3>
      <header>
        <img src={logoCadastro} alt="Cadastro" />
        <button onClick={()=>abrirFecharModalIncluir()} className="btn btn-success">Incluir Novo Professor</button>
       </header>
      <table className="table table-bordered" >
        <thead>
          <tr>
            <th>Id</th>
            <th>Nome do Professor</th>          
            <th>Atividade responsável</th>
          </tr>
        </thead>
        <tbody>
          {data.map(professor=>(
            <tr key={professor.id}>
              <td>{professor.id}</td>
              <td>{professor.nomeProfessor}</td>
              <td>{professor.atvResponsavel}</td>
             
              <td>
              <button className="btn btn-primary" onClick={()=>selecionarProfessor(professor, "Editar")}>Editar</button> {"  "}
              <button className="btn btn-danger" onClick={()=>selecionarProfessor(professor, "Excluir")}>Excluir</button>
              </td>
              </tr>
          ))}
        </tbody>
      </table>
      
      <Modal isOpen={modalIncluir}>
      <ModalHeader>Incluir Professores</ModalHeader>
      <ModalBody>
        <div className="form-group">
          <label>Nome do Professor: </label>
          <br />
          <input type="text" className="form-control" name="nomeAluno"  onChange={handleChange}/>
          <br />
          <label>Atividade Responsável: </label>
          <input type="text" className="form-control" name="atividadeResponsavel" onChange={handleChange}/>

          <br />
      
        </div>
      </ModalBody>
      <ModalFooter>
        <button className="btn btn-primary" onClick={()=>pedidoPost()}>Incluir</button>{"   "}
        <button className="btn btn-danger" onClick={()=>abrirFecharModalIncluir()}>Cancelar</button>
      </ModalFooter>
    </Modal>

    <Modal isOpen={modalEditar}>
      <ModalHeader>Editar Professor</ModalHeader>
      <ModalBody>
        <div className="form-group">
        <label>ID: </label>
        <label>Nome do Professor: </label>
          <br />
          <input type="text" className="form-control" name="nomeAluno"  onChange={handleChange}/>
          <br />
          <label>Atividade Responsável: </label>
          <input type="text" className="form-control" name="atividadeResponsavel" onChange={handleChange}/>

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
        Confirma a exclusão deste(a) professor(a) : {professorSelecionado && professorSelecionado.nomeProfessor} ?
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
    <br/><br/>
          <h6>RA: 2101477</h6>
          <h6>Nome: Júlia Reis de Aguiar</h6>
          <h6>5ºSemestre-ADS</h6>
    </div>
  );
}

export default Teacher;
