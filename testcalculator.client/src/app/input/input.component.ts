import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-input',
  templateUrl: './input.component.html',
  styleUrls: ['./input.component.css']
})
export class InputComponent {
  @Input() label: string = '';         // Etiqueta del input
  @Input() valor: number | null = null; // Valor del input
  @Input() id: string = '';             // ID para enlazar el input con su etiqueta
  @Output() valorChange = new EventEmitter<number>(); // Evento para notificar cambios

  manejarCambio(event: any) {
    const nuevoValor = event.target.valueAsNumber;
    this.valorChange.emit(nuevoValor); 
  }
}
