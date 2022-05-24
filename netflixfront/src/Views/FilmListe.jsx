import React, { Component } from 'react'

import axios, { Axios } from 'axios';
import FilmCard from './FilmCard';


export default class FilmListe extends Component {
    state={
      films:[]
    }

ComponentDidMount(){
    axios.get(`http://localhost:5000/api/Films`)
    .then(res=>{
        const arr = res.data;
        //Films: res.data;
        this.setState({films:arr})
     })


    // axios.get(`http://localhost:5000/api/Films`)
    // .then(res=>res.data)
    // .then((data)=>{
    //    // const arr = res.data
    //     //Films: res.data;
    //     this.setState({Film:data})
    // })
}

  render() {
    return (
      
      <div>
        <div>{ this.state.films.map(film => <li>{film.titre}</li>)}</div>
      <h1>film</h1>
      <div>
            <ul>
       { this.state.films.map(film => <li>{film.titre}</li>)}
       </ul>
       </div>
       </div>


    //   <div>
    //   <h1 className="center">Mes films</h1>
    //   <div className="container"> 
    //         <div className="row"> 
    //         <FilmCard Film={this.state.Film} />
    //         </div>
    //   </div>
    // </div>  
    )
  }
}
