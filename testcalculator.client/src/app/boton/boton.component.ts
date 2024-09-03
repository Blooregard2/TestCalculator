import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-boton',
  templateUrl: './boton.component.html',
  styleUrls: ['./boton.component.css']
})
export class BotonComponent {
  @Input() operacion: string = '';
  @Input() label: string = '';
  @Output() clickOperacion = new EventEmitter<string>();

  manejarClick() {
    this.clickOperacion.emit(this.operacion);
  }
}
