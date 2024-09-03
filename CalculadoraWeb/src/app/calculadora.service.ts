import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CalculadoraService {
  private apiUrl = 'https://localhost:7181/api/Operacion/Operaciones';

  constructor(private http: HttpClient) {}

  operar(Valor1: number, Valor2: number, Operacion: string): Observable<any> {
    const body = { Valor1, Valor2, Operacion };
    return this.http.post<any>(this.apiUrl, body);
  }
}
