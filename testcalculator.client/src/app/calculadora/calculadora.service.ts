import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CalculadoraService {

  private apiUrl = 'http://localhost:5000/api/calculadora'; // Cambia esto según la URL de tu API

  constructor(private http: HttpClient) { }

  realizarOperacion(numero1: number, numero2: number, operacion: string): Observable<number> {
    const data = { numero1, numero2, operacion };
    return this.http.post<number>(this.apiUrl, data);
  }
}
