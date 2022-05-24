import React from 'react';


const FilmCard = ({Film,updateFilmList }) => {
    return (
       
<div className="col s6 m4" >
    <div className="card horizontal" style={{borderColor: 'gray'}}>
    {Film.map((Film, index) => (
    // //   <div className="card-image"> 
    // //     <img src={film.picture} alt={film.name}/>
    // //   </div>
        <div className="card-stacked">
            <div className="card-content" style={{borderColor: 'gray'}} >
            <p>{Film.titre}</p>
            <p><small>{Film.anneeFilm}</small></p>
            </div>   
        </div>
    ))}
    </div> 
  </div>
 ) ;
};

export default FilmCard;