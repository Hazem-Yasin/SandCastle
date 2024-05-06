import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompenentNameComponent } from './compenent-name.component';

describe('CompenentNameComponent', () => {
  let component: CompenentNameComponent;
  let fixture: ComponentFixture<CompenentNameComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CompenentNameComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CompenentNameComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
