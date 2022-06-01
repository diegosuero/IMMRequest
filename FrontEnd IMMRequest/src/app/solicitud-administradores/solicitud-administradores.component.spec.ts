import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SolicitudAdministradoresComponent } from './solicitud-administradores.component';

describe('SolicitudAdministradoresComponent', () => {
  let component: SolicitudAdministradoresComponent;
  let fixture: ComponentFixture<SolicitudAdministradoresComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SolicitudAdministradoresComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SolicitudAdministradoresComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
