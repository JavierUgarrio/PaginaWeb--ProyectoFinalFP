import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-inicio-component',
  templateUrl: './inicio.component.html',
  styleUrls: ['./inicio.component.css']
})

export class InicioComponent {

  constructor(private router: Router) { }

  public AltaUsuario() {
    this.router.navigate(['/procesos']);
  }
}
