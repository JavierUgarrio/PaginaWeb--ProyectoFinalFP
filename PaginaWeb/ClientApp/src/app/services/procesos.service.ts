import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Login } from '../modelos/login';
//import { Proceso } from '../modelos/Proceso';
import { objetoProceso } from '../modelos/objetoProceso';
import { Resultado } from '../modelos/resultado';


@Injectable({
  providedIn: 'root'
})

export class ProcesosService
{
  url: string = 'https://localhost:7051/API/procesos/';
  constructor(private peticion: HttpClient)
  {

  }
  dameProcesos(): Observable<Resultado>
  {
    return this.peticion.get<Resultado>(this.url);
  }

  agregarProceso(proceso: objetoProceso): Observable<Resultado> {
    return this.peticion.post<Resultado>(this.url, proceso);
  }


}

