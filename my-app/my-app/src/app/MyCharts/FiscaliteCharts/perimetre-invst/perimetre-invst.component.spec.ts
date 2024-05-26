import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PerimetreInvstComponent } from './perimetre-invst.component';

describe('PerimetreInvstComponent', () => {
  let component: PerimetreInvstComponent;
  let fixture: ComponentFixture<PerimetreInvstComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PerimetreInvstComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PerimetreInvstComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
