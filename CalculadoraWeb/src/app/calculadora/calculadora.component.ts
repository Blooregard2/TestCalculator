import { Component } from '@angular/core';
import { CalculadoraService } from '../calculadora.service';

@Component({
  selector: 'app-calculadora',
  templateUrl: './calculadora.component.html',
  styleUrls: ['./calculadora.component.css']
})
export class CalculadoraComponent {
  numero1: number = 0;
  numero2: number = 0;
  total: number = 0;
  mensaje: string = '';
  factores: number[] | null = null;
  mostrarSegundoNumero: boolean = true; 

  constructor(private calculadoraService: CalculadoraService) {}

  realizarOperacion(operacion: string) {
    
    this.mostrarSegundoNumero = operacion !== 'factorial';

    // Ejecuta la operación
    this.calculadoraService.operar(this.numero1, this.numero2, operacion)
      .subscribe(
        response => {
          this.total = response.total;
          this.mensaje = response.mensaje;
          this.factores = response.factores;
        },
        error => console.error('Error realizando la operación', error)
      );
  }

  reiniciarCalculadora() {
    this.numero1 = 0;
    this.numero2 = 0;
    this.total = 0;
    this.mensaje = '';
    this.factores = null;
    this.mostrarSegundoNumero = true; 
  }
}
